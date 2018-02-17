package Algotiyhms.Razdel1.Tema2.OLD__Zadanie2_3_____;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Stack;

public class Dialog extends Thread{
    private static int maxSize = 1000000;
    private static Stack array = new Stack();
    private static int top = -1;
    private String reader;
    private boolean exit = false;
    private static BufferedReader bf = new BufferedReader(new InputStreamReader(System.in));

    public static int getMaxSize() {
        return maxSize;
    }

    public static BufferedReader getBf() {
        return bf;
    }

    public static Stack getArray() {
        return array;
    }

    public static void setArray(Stack array) {
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
                "\nПроверить пустоту стека - \"1\"" +
                "\nПроверка заполненности стекового массива - \"2\"" +
                "\nДобавить элемент в вершину стека - \"3\"" +
                "\nУдалить элемент из вершины стека - \"4\"" +
                "\nВывод текущего состояния стека на экран - \"5\"" +
                "\nДобавить несколько элементов в вершину стека - \"6\"" +
                "\nДля выхода нажмите \"7\"");
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
            if (choice > 0 && choice < 8) {
                switch (choice) {
                    case 1:
                        //  System.out.println("работает");
                        new EmptyCheck(top);
                        break;
                    case 2:
                        new FullCheck(top, maxSize);
                        break;
                    case 3:
                        new Push(top, maxSize);
                        break;
                    case 4:
                        new Pop(top);
                        break;
                    case 5:
                        new View(array);
                        break;
                    case 6:
                        new PushSeveral();
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
