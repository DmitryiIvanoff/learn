package Algotiyhms.Razdel1.Tema2.Zadanie2_3_new;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Dialog extends Thread{
    private String reader;
    private boolean exit = false;

    private static BufferedReader bf = new BufferedReader(new InputStreamReader(System.in));

      public Dialog() {
        System.out.println ("Что желаете сделать?" +
                "\nПроверить пустоту стека - \"1\"" +
                "\nДобавить элемент в вершину стека - \"2\"" +
                "\nУдалить элемент из вершины стека - \"3\"" +
                "\nВывод текущего состояния стека на экран - \"4\"" +
                "\nДобавить несколько элементов в вершину стека - \"5\"" +
                "\nДля выхода нажмите \"6\"");
    }
    public void run(){
        DynamicStack dynamicStack = new DynamicStack();

        while(!exit){
            try {
                this.reader = bf.readLine();
            }
            catch (IOException e){
                System.out.println("Wrong input");
            }
        if(!reader.equals(null) && !reader.equals("")) {

            int choice = Integer.parseInt(reader);
            if (choice > 0 && choice < 7) {
                switch (choice) {
                    case 1:
                       dynamicStack.checkIsEmpty();
                        break;
                    case 2:
                        dynamicStack.push();
                        dynamicStack.view();
                        break;
                    case 3:
                        dynamicStack.pop();
                        break;
                    case 4:
                        dynamicStack.view();
                        break;
                    case 5:
                        System.out.println("Сколько элементов добавить?");
                        try {
                            reader = bf.readLine();
                            dynamicStack.popSeveral(Integer.parseInt(reader));
                        }
                        catch (IOException e){
                        }

                        break;
                    case 6:
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
