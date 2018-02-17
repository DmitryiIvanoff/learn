package Algotiyhms.Razdel1.Tema2.Zadanie2_3_____;

import java.util.Stack;

public class Push {
    public Push(int top, int maxSize) {

        Stack array = Dialog.getArray();
        Dialog.setTop(++top);
        array.push((int) (5000 * Math.random()));
        Dialog.setArray(array);
    }

}
