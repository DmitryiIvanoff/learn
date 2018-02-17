package Algotiyhms.Razdel1.Tema2.Zadanie6;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Dialog extends Thread{
    private static DynamicQueue queue = new DynamicQueue(5);
    private static DynamicQueue dynamicQueue = new DynamicQueue(2);
    private String reader;
    private boolean exit = false;

    public Dialog() {
        System.out.println ("Что желаете сделать?" +
                "\nПроверить пустоту  - \"1\"" +
                "\nДобавить элемент  - \"3\"" +
                "\nУдалить элемент  - \"4\"" +
                "\nВывод текущего состояния на экран - \"5\"" +
                "\nДля выхода нажмите \"7\"" ) ;
    }
    public void run(){
        BufferedReader bf = new BufferedReader(new InputStreamReader(System.in));

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
                        queue.emptyCheck();
                        break;
                    case 3:
                       queue.add((int) (5000 * Math.random()));
                       queue.view();
                        break;
                    case 4:
                        queue.remove();
                        queue.view();
                        break;
                    case 5:
                        queue.view();
                        break;
                    case 7:
                        exit = true;
                        try {
                            bf.close();
                        }
                        catch (IOException e){
                        }
                        break;
                    case 8:
                        dynamicQueue.view();
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
