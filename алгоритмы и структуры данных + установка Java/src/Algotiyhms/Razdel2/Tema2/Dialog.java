package Algotiyhms.Razdel2.Tema2;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Dialog extends Thread{
    public String reader;
    private boolean exit = false;
    private static BufferedReader bf = new BufferedReader(new InputStreamReader(System.in));
    SortingClass sort;
    int[] array;
    int[] arrayReserve;
    long start, finish;

    public static BufferedReader getBf() {
        return bf;
    }



    public Dialog() {
        System.out.println ("Что желаете сделать?" +
                "\nSozdat massiv  - \"1\"" +
                "\nSortirovka puzirkom  - \"2\"" +
                "\nSortirovka vstavkami   - \"3\"" +
                "\nSortirovka viborkami - \"4\"" +
                "\nSortirovka Shell - \"5\"" +
                "\nSortirovka bistraya - \"6\"" +
                "\nДля выхода нажмите \"7\"" +
                "\nSortirovka Upgraded Choice - \"8\"") ;
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
                        sort = new SortingClass();
                        array = (sort.generateArray(40000));
                        arrayReserve = new int[array.length];
                        System.arraycopy( array, 0, arrayReserve, 0, array.length );
                        sort.printArray(array);
                        System.out.println("=================================");
                        break;
                    case 2:
                        System.arraycopy( arrayReserve, 0, array, 0, arrayReserve.length );
                        sort.printArray(array);
                        start = System.currentTimeMillis();
                        sort.bubbleSorting(array);
                        finish = System.currentTimeMillis();
                        sort.printArray(array);
                        System.out.println("time elapsed: " + (finish - start) + " ms");
                        System.out.println("=================================");

                        break;
                    case 3:
                        System.arraycopy( arrayReserve, 0, array, 0, arrayReserve.length );
                        sort.printArray(array);
                        start = System.currentTimeMillis();
                        sort.insertionSorting(array);
                        finish = System.currentTimeMillis();
                        sort.printArray(array);
                        System.out.println("time elapsed: " + (finish - start) + " ms");
                        System.out.println("=================================");

                        break;
                    case 4:
                        System.arraycopy( arrayReserve, 0, array, 0, arrayReserve.length );
                        sort.printArray(array);
                        start = System.currentTimeMillis();
                        sort.chooseSorting(array);
                        finish = System.currentTimeMillis();
                        sort.printArray(array);
                        System.out.println("time elapsed: " + (finish - start) + " ms");

                        break;
                    case 5:
                        System.arraycopy( arrayReserve, 0, array, 0, arrayReserve.length );
                        sort.printArray(array);
                        start = System.currentTimeMillis();
                        sort.shellSort(array);
                        finish = System.currentTimeMillis();
                        sort.printArray(array);
                        System.out.println("time elapsed: " + (finish - start) + " ms");
                        break;
                    case 6:
                        System.arraycopy( arrayReserve, 0, array, 0, arrayReserve.length );
                        sort.printArray(array);
                        start = System.currentTimeMillis();
                        array = sort.fastSorting(array);
                        finish = System.currentTimeMillis();
                        sort.printArray(array);
                        System.out.println("time elapsed: " + (finish - start) + " ms");
                        break;

                    case 7:
                        exit = true;
                        break;

                    case 8:
                        System.arraycopy( arrayReserve, 0, array, 0, arrayReserve.length );
                        sort.printArray(array);
                        start = System.currentTimeMillis();
                        sort.upgradedChooseSorting(array);
                        finish = System.currentTimeMillis();
                        sort.printArrayFromEnd(array);
                        System.out.println("time elapsed: " + (finish - start) + " ms");
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
