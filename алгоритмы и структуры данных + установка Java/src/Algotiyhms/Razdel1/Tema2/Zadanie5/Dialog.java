package Algotiyhms.Razdel1.Tema2.Zadanie5;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Dialog extends Thread{
    private static Queue queue = new Queue(5);
    private static Queue deletedQueue = new Queue(2);
    private String reader;
    private boolean exit = false;


    public String getReader() {
        return reader;
    }

    public void setReader(String reader) {
        this.reader = reader;
    }

    public static Queue getDeletedQueue() {
        return deletedQueue;
    }

    public static void setDeletedQueue(Queue deletedQueue) {
        Dialog.deletedQueue = deletedQueue;
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
                    case 2:
                        queue.fullCheck();
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
                        try{
                            bf.close();
                        }
                        catch(IOException e){
                        }
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
