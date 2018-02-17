package Algotiyhms.Razdel1.Tema5.Zadanie1;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Dialog extends Thread{
    private String reader;
    private boolean exit = false;
    private static BufferedReader bf = new BufferedReader(new InputStreamReader(System.in));


    public static BufferedReader getBf() {
        return bf;
    }



    public Dialog() {
        System.out.println ("Что желаете сделать?" +
                "\nPostroit derevo  - \"1\"" +
                "\nДобавить элемент  - \"3\"" +
                "\nУдалить элемент  - \"4\"" +
                "\nВывод текущего состояния на экран - \"5\"" +
                "\nДля выхода нажмите \"7\"" ) ;
    }
    public void run(){

        while(!exit){

           try {
                this.reader = bf.readLine();
            }
           catch (IOException e){
                System.out.println("Wrong input");
           }
        if(!reader.equals(null) && !reader.equals("")) {

            int choice = Integer.parseInt(reader);
            if (choice > 0 && choice < 9) {
                switch (choice) {
                    case 1:
                     //   SortingClass tree = new SortingClass(100);
                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 7:
                        exit = true;
                        break;
                }

            }
            else{
                System.out.println("Недопустимое действие");
                continue;
            }
        }
        else{

                System.out.println("Выберете пункт меню");
        }
        }
    }
}
