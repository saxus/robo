
import java.io.IOException;
import java.io.File;
import java.io.FileNotFoundException;
import java.util.HashSet;
import java.util.NoSuchElementException;
import java.util.Scanner;


/**
 * SokobanTester solves easy to moderate sokoban puzzles using different search algorithms.
 * Search algorithms are based on the textbook pseudocode, and Hungarian Algorithm is from wikipedia.
 * @author Hyun Seung Hong (hh2473)
 *
 */
public class A {
    public static void main(String[] args)
    {
        try {
			SokobanSolver s =  new SokobanSolver();
            int numPlayer = s.loadFile("input2.txt", 'm');
            System.out.println("ANSWER");
            String answer = s.solve('a');
            System.out.println(answer);
            System.out.println("TADA");
		} catch (IOException e) {
			System.out.println("IO Exception occured");
			e.printStackTrace();
		}
    }
}