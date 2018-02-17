package Algotiyhms.Razdel1.Tema2.Zadanie7;

public class MainClass  {

    public static void main(String[] args) throws InterruptedException{


        ControlQueue controlQueue = new ControlQueue();
        controlQueue.start();
        Thread.sleep(300);
        Cycle cycle = new Cycle();
        cycle.start();

    }
}
