package Algotiyhms.Razdel1.Tema2.Zadanie5;

import java.io.IOException;


public class Push {
    int answer;
    public Push(int top,  boolean yesQuestion){
        int i;
if(yesQuestion) {
    System.out.println("Добавить новый элемент (1) или взять из стека удаленных элементов? (2)");
    try {
        answer = Integer.parseInt(Dialog.getBf().readLine());
    } catch (IOException r) {
    }

    if (answer == 2) {

        if(!Dialog.getDeletedArray().empty()) {
            i = (int) Dialog.getDeletedArray().peek();
            Dialog.getDeletedArray().remove();
            Queue array = Dialog.getArray();
            Dialog.setTop(++top);
            array.add(i);
            Dialog.setArray(array);
        }
        else {
            System.out.println("Стек удаленных элементов пуст");
        }

    }
    else{
        i = (int) (5000 * Math.random());
        Queue array = Dialog.getArray();
        Dialog.setTop(++top);
        array.add(i);
        Dialog.setArray(array);
    }
}
            else{
                i = (int) (5000 * Math.random());
                Queue array = Dialog.getArray();
                Dialog.setTop(++top);
                array.add(i);
                Dialog.setArray(array);
            }


    }
}
