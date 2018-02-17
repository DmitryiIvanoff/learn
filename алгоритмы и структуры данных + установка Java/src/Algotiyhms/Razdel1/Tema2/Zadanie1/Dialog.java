package Algotiyhms.Razdel1.Tema2.Zadanie1;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Dialog extends Thread{

    private String reader;
    private boolean exit = false;
    Stack stack = new Stack(20);

    public Dialog() {
        System.out.println ("Что желаете сделать?" +
                "\nПроверить пустоту стека - \"1\"" +
                "\nПроверка заполненности стекового массива - \"2\"" +
                "\nДобавить элемент в вершину стека - \"3\"" +
                "\nУдалить элемент из вершины стека - \"4\"" +
                "\nВывод текущего состояния стека на экран - \"5\"" +
                "\nДля выхода нажмите \"6\"");
    }
    public void run(){
        try (BufferedReader bf = new BufferedReader(new InputStreamReader(System.in))){
        while(!exit) {

                this.reader = bf.readLine();

                if (!reader.equals(null) && !reader.equals("")) {

                    int choice = Integer.parseInt(reader);
                    if (choice > 0 && choice < 7) {
                        switch (choice) {
                            case 1:
                                stack.emptyCheck();
                                break;
                            case 2:
                                stack.fullCheck();
                                break;
                            case 3:
                                stack.push();
                                stack.view();
                                break;
                            case 4:
                                stack.pop();
                                stack.view();
                                break;
                            case 5:
                                stack.view();
                                break;
                            case 6:
                                exit = true;
                                break;
                        }

                    } else {
                        System.out.println("Недопустимое действие");
                        continue;
                    }
                } else {

                    System.out.println("Выберете пункт меню");


                }
            }
            }
        catch (IOException e) {
            System.out.println("Wrong input");
        }

    }
}
