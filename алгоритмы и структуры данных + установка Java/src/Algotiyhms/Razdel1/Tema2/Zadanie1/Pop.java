package Algotiyhms.Razdel1.Tema2.Zadanie1;

public class Pop {
    public Pop(int top) {
        if(top != -1){
            int[] array = Dialog.getArray();
            array[top--] = 0;
            Dialog.setTop(top);
            Dialog.setArray(array);
        }
        else{
            new EmptyCheck(top);
        }

    }
}
