package Algotiyhms.Razdel1.Tema3.Zadanie4;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Dialog extends Thread{
    private static List array = new List();
    private String reader;
    private boolean exit = false;
    private static BufferedReader bf = new BufferedReader(new InputStreamReader(System.in));


    public static BufferedReader getBf() {
        return bf;
    }

    public static List getArray() {
        return array;
    }

    public static void setArray(List array) {
        Dialog.array = array;
    }

    public Dialog() {
        System.out.println ("Что желаете сделать?" +
                "\nДобавить элемент  по индексу - \"2\"" +
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
                    case 2:
                    try{
                        System.out.println("Vvedite index");
                        array.add((int)(5000 * Math.random()), Integer.parseInt(bf.readLine()));
                        array.printList();
                    }
                    catch (IOException r){

                    }
                    break;

                    case 3:
                        array.add((int) (5000 * Math.random()));
                        array.printList();
                        break;
                    case 4:
                        try{
                            System.out.println("Vvedite index");
                            array.remove(Integer.parseInt(bf.readLine()));
                            array.printList();
                        }
                        catch (IOException r){
                        }
                        break;
                    case 5:
                      //  array.view();
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
