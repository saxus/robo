import java.io.File;
import java.io.FileNotFoundException;
import java.util.HashSet;
import java.util.NoSuchElementException;
import java.util.Scanner;

/**
 * SokobanSolver loads the input file and stores each character into appropriate set (walls, goals, boxes or player)
 * After the file is read, it calls Search class to solve the sokoban puzzle according to the chosen search method.
 * @author Hyun Seung Hong (hh2473)
 *
 */
public class SokobanSolver {
	
	private HashSet<Coordinate> walls;
	private HashSet<Coordinate> goals;
	private HashSet<Coordinate> boxes;
	
	private Coordinate player;
	private Problem prob;
	private Heuristics h;
	
	private int row;
	private int col;
	
	public SokobanSolver() {
	}
	
	/**
	 * Reads each line from the input file and adds each character to walls, goals, player or boxes
	 * @param filename
	 * @return
	 * @throws FileNotFoundException
	 * @throws NumberFormatException
	 * @throws NoSuchElementException
	 */
	public int loadFile(String filename, char hChoice) throws FileNotFoundException, 
			NumberFormatException, NoSuchElementException {
		
		col = 0;
		int numPlayer = 0;
		walls = new HashSet<Coordinate>();
		goals = new HashSet<Coordinate>();
		boxes = new HashSet<Coordinate>();
		Scanner s = new Scanner(new File(filename));
		row = Integer.parseInt(s.nextLine());
		for (int i=0; i<row; i++) {
			String next = s.nextLine();
			for (int j=0; j<next.length(); j++) {
				char c = next.charAt(j);
				if (c=='#') //walls
					walls.add(new Coordinate(i, j));
				if (c == '@' || c == '+') { //player
					player = new Coordinate(i, j);
					numPlayer++;
				}
				if (c == '.' || c == '+' || c == '*') //goals
					goals.add(new Coordinate(i, j));
				if (c == '$' || c == '*') //boxes
					boxes.add(new Coordinate(i,j));
			}
			if (next.length() > col)
				col = next.length();
		}
		prob = new Problem(walls, new State(boxes, player), goals);
		h = new Heuristics(goals, hChoice);
		System.out.println("row: " + row + ", col: " + col);
		return numPlayer;
	}

	/**
	 * Calls appropriate search method to solve the puzzle
	 * @param method
	 * @return
	 */
	public String solve(char method) {
		Search s = new Search(h);
		switch(method) {
		case 'b':
			return s.bfs(prob);
		case 'd':
			return s.dfs(prob);
		case 'u':
			return s.prioritySearch(prob, 'u');
		case 'a':
			return s.prioritySearch(prob, 'a');	
		case 'g':
			return s.prioritySearch(prob, 'g');
		default:
			return "Invalid method, please choose a valid search method.";
		}
	}

	public int getRow() {
		return row;
	}
	
	public int getCol() {
		return col;
	}

	public HashSet<Coordinate> getWalls() {
		return walls;
	}
	
	public HashSet<Coordinate> getBoxes() {
		return boxes;
	}
	
	public HashSet<Coordinate> getGoals() {
		return goals;
	}
	
	public Coordinate getPlayer() {
		return player;
	}
}
