package Algotiyhms.Razdel1.Tema2.Zadanie4;

import java.io.IOException;

import java.math.BigInteger;

public class PushSeveral {
    public PushSeveral() {
        try {
            System.out.println(String.format("Сколько элементов добавить?", Dialog.getMaxSize() - Dialog.getTop()-1) );
            BigInteger number = new BigInteger(Dialog.getBf().readLine());
            for (BigInteger i = BigInteger.ZERO; i.compareTo(number) == -1; i = i.add(BigInteger.ONE)){
                new Push(Dialog.getTop(),  false);
            }
            System.out.println(number + " elements added");
        }
        catch (IOException e){
            System.out.println("Wrong input");
        }
    }
}
