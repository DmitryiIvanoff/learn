package Algotiyhms.Razdel1.Tema2.Zadanie2_3_____;

import java.util.Stack;

public class Pop {
    public Pop(int top) {
        if(top != -1){
            Stack array = Dialog.getArray();
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
