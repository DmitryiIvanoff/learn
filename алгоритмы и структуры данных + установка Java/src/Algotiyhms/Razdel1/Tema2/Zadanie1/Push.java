package Algotiyhms.Razdel1.Tema2.Zadanie1;

public class Push {
    public Push(int top, int maxSize){
        if(top < maxSize - 1){
        int[] array = Dialog.getArray();
        Dialog.setTop(++top);
        array[top] = (int) (5000 * Math.random());
        Dialog.setArray(array);
        }
        else{
            new FullCheck(top, maxSize);
        }
    }
}
