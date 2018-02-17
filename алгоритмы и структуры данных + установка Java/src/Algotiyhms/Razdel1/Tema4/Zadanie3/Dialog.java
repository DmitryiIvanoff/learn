package Algotiyhms.Razdel1.Tema4.Zadanie3;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Dialog extends Thread{
    private static LinkedList array = new LinkedList();
    ListOfLinkedLists listOfLists = new ListOfLinkedLists();
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
                "\nПросмотр списка  - \"1\"" +
                "\nДобавить новый список - \"2\"" +
                "\nДобавить новый элемент в список  - \"3\"" +
                "\nУдалить список - \"4\"" +
                "\nУдалить элемент  - \"5\"" +
                "\nПоиск заданного элемента  - \"6\"" +
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
            if (choice > 0 && choice < 8) {
                switch (choice) {
                    case 1:
                        listOfLists.printList();
                        break;

                    case 2:
                        listOfLists.addNewList(0);
                        listOfLists.printList();
                        break;

                    case 3:
                        System.out.println("V kakoy spisok dobavit?");
                        try{
                            reader = bf.readLine();
                            int listNumber = Integer.parseInt(reader);
                            listOfLists.getLinkedList(listNumber).add((int)(Math.random()*5000));
                        }
                        catch (IOException e){
                        }
                        listOfLists.printList();
                        break;

                    case 4:
                        System.out.println("Kakoy spisok udalit?");
                        try{
                            reader = bf.readLine();
                            listOfLists.delete(Integer.parseInt(reader));
                            listOfLists.printList();
                        }
                        catch (IOException e){
                        }
                        break;
                    case 5:
                        System.out.println("Iz kakogo spiska udalit?");
                        try{
                            reader = bf.readLine();
                            int listNumber = Integer.parseInt(reader);
                            System.out.println("Kakaoy element udalit?");
                            reader = bf.readLine();
                            listOfLists.getLinkedList(listNumber).delete(Integer.parseInt(reader));
                        }
                        catch (IOException e){
                        }
                        listOfLists.printList();
                        break;
                    case 6:
                        System.out.println("Kakaoy element nayti?");
                        try{
                            reader = bf.readLine();
                            listOfLists.search(Integer.parseInt(reader));
                        }
                        catch (IOException e){

                        }

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
