import java.io.*;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

class Jatekos {
    String nev;
    Integer[] tippek;

    Jatekos(String nyersBemenet) {
        String[] darabolva = nyersBemenet.split(" ");
        nev = darabolva[0];
        tippek = new Integer[darabolva.length - 1];

        for (int i = 1; i < darabolva.length; i++) {
            tippek[i - 1] = Integer.parseInt(darabolva[i]);
        }
    }
}

public class Egyszamjatek {
    private static List<Jatekos> tippLista = new ArrayList<Jatekos>();
    private static Integer bemenet;

    public static void main(String[] args) {
        File inputFile = new File("./egyszamjatek.txt");
        try (Scanner scanner = new Scanner(inputFile)) {
            while (scanner.hasNextLine()) {
                String aktualisSor = scanner.nextLine();
                Jatekos jatekos = new Jatekos(aktualisSor);
                tippLista.add(jatekos);
            }
        } catch (FileNotFoundException exception) {
            System.err.print("Fájl nem található!");
        }

        System.out.println("3. feladat: Játékosok száma: " + tippLista.size() + " fő");
        Scanner consoleScanner = new Scanner(System.in);
        System.out.print("4. feladat: Kérem a forduló sorszámát: ");
        bemenet = consoleScanner.nextInt();
        Integer szumma = 0;
        for (Jatekos jatekos : tippLista) {
            szumma += jatekos.tippek[bemenet - 1];
        }
        DecimalFormat df2 = new DecimalFormat("#.##");

        System.out.println("5. feladat: A megadott forduló tippjeinek átlaga: " + df2.format(Double.valueOf(szumma) / (double) tippLista.size()));
    }
}