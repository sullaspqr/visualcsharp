import javafx.application.Application;
import javafx.event.EventHandler;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.scene.input.MouseEvent;
import javafx.stage.Stage;
import javafx.beans.value.ChangeListener;
import javafx.beans.value.ObservableValue;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

class Jatekos {
    String nev;
    Integer[] tippek;
    Jatekos(String fajlSor) {
        String[] darabolva = fajlSor.split(" ");
        nev = darabolva[0];
        tippek = new Integer[darabolva.length - 1];
        for (int i = 1; i < darabolva.length; i++) {
            tippek[i - 1] = Integer.parseInt(darabolva[i]);
        }
    }
}

public class EgyszamjatekGUI extends Application {
    private static List<Jatekos> tippLista = new ArrayList<>();

    @Override
    public void start(Stage primaryStage) throws IOException {
        Parent root = FXMLLoader.load(getClass().getResource("EgyszamjatekGUI.fxml"));
        primaryStage.setTitle("Egyszámjáték");
        primaryStage.setScene(new Scene(root, 400, 150));
        TextField jatekosNevInput = (TextField) primaryStage.getScene().lookup("#jatekosNevInput");
        TextField jatekosTippInput = (TextField) primaryStage.getScene().lookup("#jatekosTippInput");
        Button jatekosHozzadasaGomb = (Button) primaryStage.getScene().lookup("#jatekosHozzadasaGomb");
        Label tippekSzamaFelirat = (Label) primaryStage.getScene().lookup("#tippekSzamaFelirat");
        primaryStage.show();

        jatekosTippInput.textProperty().addListener((obs, oldText, newText) ->
                tippekSzamaFelirat.setText(newText.isEmpty() ? "" : newText.split(" ").length + " db."));

        // vs:

        // jatekosTippInput.textProperty().addListener(new ChangeListener<String>() {
        // @Override
        //   public void changed(ObservableValue<? extends String> observable, String oldValue, String newValue) {
        //         tippekSzamaFelirat.setText(newValue.isEmpty() ? "" : newValue.split(" ").length + " db.");
        //    }
        // });


        File inputFile = new File("./egyszamjatek.txt");

        try (Scanner scanner = new Scanner(inputFile)) {
            while (scanner.hasNextLine()) {
                String aktualisSor = scanner.nextLine();
                Jatekos jatekos = new Jatekos(aktualisSor);
                tippLista.add(jatekos);
            }
        } catch (FileNotFoundException e) {
            System.err.println(e.getMessage());
        }

        EventHandler<MouseEvent> kattintasKezelo = event -> {
            if (felhasznaloHozzadasa(jatekosNevInput.textProperty().getValue(), jatekosTippInput.textProperty().getValue())) {
                jatekosNevInput.textProperty().setValue("");
                jatekosTippInput.textProperty().setValue("");
            }
        };

        jatekosHozzadasaGomb.addEventHandler(MouseEvent.MOUSE_CLICKED, kattintasKezelo);
    }

    private boolean felhasznaloHozzadasa(String ujFelhasznaloNev, String tippInput) {
        if (tippLista.stream().map(x -> x.nev).anyMatch(x -> x.equals(ujFelhasznaloNev))) {
            hibauzenetLetrehozas("Már van ilyen nevű játékos!");
            return false;
        }

        if (tippLista.get(0).tippek.length != tippInput.split(" ").length) {
            hibauzenetLetrehozas("A tippek száma nem megfelelő!");
            return false;
        }

        String jatekosBejegyzes = ujFelhasznaloNev + " " + tippInput;
        Jatekos ujJatekos = new Jatekos(jatekosBejegyzes);
        tippLista.add(ujJatekos);
        try {
            Files.write(Paths.get("./egyszamjatek.txt"), (jatekosBejegyzes + System.lineSeparator()).getBytes(), StandardOpenOption.APPEND);
            Alert alert = new Alert(Alert.AlertType.INFORMATION);
            alert.setTitle("Üzenet");
            alert.setHeaderText(null);
            alert.setContentText("Az állomány bővítése sikeres volt!");
            alert.showAndWait();
        } catch (IOException e) {
            System.err.println(e.getMessage());
            return false;
        }
        return true;
    }

    private void hibauzenetLetrehozas(String uzenet) {
        Alert alert = new Alert(Alert.AlertType.ERROR);
        alert.setTitle("Hiba!");
        alert.setHeaderText(null);
        alert.setContentText(uzenet);
        alert.showAndWait();
    }


    public static void main(String[] args) {
        launch(args);
    }
}

//    Alternatív megoldási lehetőségek:
//******************************************
//        8. feladat Eseménykezelés EventHandler segítségével:
//
//        EventHandler<InputEvent> inputEsemenyKezelo = new EventHandler<InputEvent>() {
//            @Override
//            public void handle(InputEvent e) {
//                System.out.println("update:" + e);
//                tippekSzamaFelirat.setText(e.toString());
//            }
//        };
//        jatekosTippInput.addEventFilter(InputEvent.ANY, inputEsemenyKezelo);
// *****************************************
//       9. feladat: felhasználónév foglaltság Stream Api használata nélkül pl.:
//
//        boolean felhasznalonevFoglalt = false;
//        for (Jatekos jatekos : tippLista) {
//            if (jatekos.nev.equals(ujFelhasznaloNev)) {
//                felhasznalonevFoglalt = true;
//                break;
//            }
//        }