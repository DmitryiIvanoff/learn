package Algotiyhms.Razdel1.Tema3.Zadanie1;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Dialog extends Thread{
    private static List array = new List(10);
    private String reader;
    private boolean exit = false;
    private static BufferedReader bf = new BufferedReader(new InputStreamReader(System.in));



    public static BufferedReader getBf() {
        return bf;
    }

    public Dialog() {
        System.out.println ("Что желаете сделать?" +
                "\nПоиск  - \"1\"" +
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
                        try{
                            System.out.println("Vvedite chislo dlya poiska");
                            array.search(Integer.parseInt(bf.readLine()));
                        }
                     catch (IOException r){

                     }
                        break;

                    case 3:
                       //array.add((int) (5000 * Math.random()), (int)(10 * Math.random()));
                        array.add((int) (5000 * Math.random()), 3);

                       array.view();
                        break;
                    case 4:
                      //  array.remove((int)(10 * Math.random()));
                        array.remove(5);
                        array.view();
                        break;
                    case 5:
                        array.view();
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
