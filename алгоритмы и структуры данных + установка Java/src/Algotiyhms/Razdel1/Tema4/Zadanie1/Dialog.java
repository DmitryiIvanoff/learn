package Algotiyhms.Razdel1.Tema4.Zadanie1;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Dialog extends Thread{
    private static LinkedList array = new LinkedList();
    private String reader;
    private boolean exit = false;
    private static BufferedReader bf = new BufferedReader(new InputStreamReader(System.in));


    public static BufferedReader getBf() {
        return bf;
    }

    public static LinkedList getArray() {
        return array;
    }

    public static void setArray(LinkedList array) {
        Dialog.array = array;
    }

    public Dialog() {
        System.out.println ("Что желаете сделать?" +
                "\nПросмотр в прямом направлении  - \"1\"" +
                "\nПросмотр в обратном направлении  - \"2\"" +
                "\nПоиск в прямом направлении  - \"3\"" +
                "\nПоиск в обратном направлении  - \"4\"" +
                "\nДобавить элемент по индексу  - \"5\"" +
                "\nДобавить элемент  - \"6\"" +
                "\nУдалить элемент  - \"7\"" +
                "\nДля выхода нажмите \"8\"" ) ;
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
                        array.printList();
                        break;

                    case 2:
                        array.printListBackward();
                        break;

                    case 3:
                        System.out.println("Vvedite chislo ");
                        try{
                            reader = bf.readLine();
                            array.search(LinkedList.forward, Integer.parseInt(reader));
                        }
                        catch (IOException e){
                        }
                        break;

                    case 4:
                        System.out.println("Vvedite chislo ");
                        try{
                            reader = bf.readLine();
                            array.search(LinkedList.backward, Integer.parseInt(reader));
                        }
                        catch (IOException e){
                        }
                        break;

                    case 5:
                        System.out.println("Vvedite index");
                        try{
                            reader = bf.readLine();
                            array.add((int) (5000 * Math.random()), Integer.parseInt(reader));
                            array.printList();
                        }
                        catch (IOException e){
                        }
                        break;
                    case 6:
                       array.add((int) (5000 * Math.random()));
                      array.printList();
                        break;
                    case 7:
                        System.out.println("Kakaoy element udalit?");
                        try{
                            reader = bf.readLine();
                            array.delete(Integer.parseInt(reader));
                            array.printList();
                        }
                        catch (IOException e){

                        }

                        break;
                    case 8:
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
