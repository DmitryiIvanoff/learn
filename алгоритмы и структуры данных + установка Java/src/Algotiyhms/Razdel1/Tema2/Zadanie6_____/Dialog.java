package Algotiyhms.Razdel1.Tema2.Zadanie6_____;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Dialog extends Thread{
    private static int maxSize ;
    private static DynamicQueue array = new DynamicQueue(5);
    private static DynamicQueue deletedArray = new DynamicQueue(2);
    private static int top = -1;
    private String reader;
    private boolean exit = false;
    private static BufferedReader bf = new BufferedReader(new InputStreamReader(System.in));

    public String getReader() {
        return reader;
    }

    public void setReader(String reader) {
        this.reader = reader;
    }

    public static DynamicQueue getDeletedArray() {
        return deletedArray;
    }

    public static void setDeletedArray(DynamicQueue deletedArray) {
        Dialog.deletedArray = deletedArray;
    }

    public static int getMaxSize() {
        return maxSize;
    }

    public static BufferedReader getBf() {
        return bf;
    }

    public static DynamicQueue getArray() {
        return array;
    }

    public static void setArray(DynamicQueue array) {
        Dialog.array = array;
    }

    public static int getTop() {
        return top;
    }

    public static void setTop(int top) {
        Dialog.top = top;
    }

    public Dialog() {
        System.out.println ("Что желаете сделать?" +
                "\nПроверить пустоту  - \"1\"" +
                "\nПроверка заполненности  - \"2\"" +
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
                        new EmptyCheck(top);
                        break;
                    case 2:
                        new FullCheck(top, maxSize);
                        break;
                    case 3:
                       array.add((int) (5000 * Math.random()));
                       array.view();
                        break;
                    case 4:
                        array.remove();
                        array.view();
                        break;
                    case 5:
                        new View(array);
                        break;
                    case 7:
                        exit = true;
                        break;
                    case 8:
                        new View(deletedArray);
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
           /* synchronized (this) {
                try {
                    this.wait(290);
                } catch (InterruptedException e) {

                }
            }
            */
        }
    }
}
