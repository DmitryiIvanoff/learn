package Algotiyhms.Razdel1.Tema2.Zadanie7;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class ControlQueue extends  Thread {
    private static boolean stopped = false;

    private final static Object mutex = new Object();

    public static Object getMutex() {
        return mutex;
    }

    public static boolean isStopped() {
        return stopped;
    }



    public void run() {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));

            while (true) {
                try {
                    String consoleString = br.readLine();
                    if (consoleString.equals("q")) {
                        stopped = true;
                    }
                    else {
                        if (consoleString.equals("w")) {
                            synchronized (mutex) {
                                stopped = false;
                                mutex.notify();
                            }

                        }
                    }

                } catch (IOException r) {

                }
            }
        }

}
