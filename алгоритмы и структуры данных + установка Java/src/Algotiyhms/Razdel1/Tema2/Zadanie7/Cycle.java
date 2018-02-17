package Algotiyhms.Razdel1.Tema2.Zadanie7;

public class Cycle  extends Thread {
    private static DynamicQueue array = new DynamicQueue(0);
    private static int top = -1;
    private Object mutex;

    public static DynamicQueue getArray() {
        return array;
    }

    public static void setArray(DynamicQueue array) {
        Cycle.array = array;
    }

    public static int getTop() {
        return top;
    }

    public static void setTop(int top) {
        Cycle.top = top;
    }


    public void run() {
            mutex = ControlQueue.getMutex();

            try {
                while (true) {
                    synchronized (mutex) {
                        if(ControlQueue.isStopped()){
                            mutex.wait();
                        }
                        int randomChoice = (int) (Math.random() * 10);
                        if (randomChoice % 2 == 0) {
                            int randomQuantity = (int) (Math.random() * 3);
                            for (int i = randomQuantity; i < 3; i++) {
                                array.add((char) (65 + Math.random() * 25));
                                array.view();
                            }
                        } else {
                            int randomQuantity = (int) (Math.random() * 3);
                            for (int i = randomQuantity; i < 3; i++) {
                                array.remove();
                                array.view();
                            }
                        }

                    }
                    this.sleep(1000);
                }


            } catch(InterruptedException t){
            }
        }
    }


