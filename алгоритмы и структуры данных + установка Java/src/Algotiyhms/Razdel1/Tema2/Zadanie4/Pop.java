package Algotiyhms.Razdel1.Tema2.Zadanie4;

import java.io.IOException;


public class Pop {
    int answer;
    public Pop(int top) {
        if(top != -1){
            Stack array = Dialog.getArray();
            System.out.println("Удалить окончательно (1) или добавить в стек удаленных элементов? (2)");
            try {
               answer = Integer.parseInt(Dialog.getBf().readLine());
            }
            catch (IOException r){
            }
            if(answer == 2) {
                int i = (int)array.peek();
                new DeletedStack(i);
            }
            array.pop();
            top--;
            Dialog.setTop(top);
            Dialog.setArray(array);
        }
        else{
            new EmptyCheck(top);
        }

    }
}
