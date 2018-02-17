package Algotiyhms.Razdel1.Tema2.Zadanie4;

public class Stack {
    Object[] array;
    int top = -1;

    public int getLength() {
        return array.length;
    }

    public Object[] getArray() {
        return array;
    }


    public void push(Object e){
        top++;
        if(top != 0){
            Object[] temp = array;
            array = null;
            array =  new Object[top + 1];
            for(int i = 0 ; i < temp.length; i++){
                array[i] = temp[i];
            }
                      }
        else{
        array = new Object[1];
        }
        array[top] = e;

    }
    public Object peek(){
        return array[top];
    }

    public void pop() {
        top--;
        if(top >= -1 ){
            Object[] temp = new Object[top + 1];
            for(int i = 0 ; i < temp.length; i++){
                temp[i] = array[i];
            }
            array = null;
            array = temp;
        }
        else{
            top++;
        }
    }
    public boolean empty(){
        boolean isEmpty;
        if(top == -1){
            isEmpty = true;
        }
        else{
            isEmpty = false;
        }
        return isEmpty;
    }
}
