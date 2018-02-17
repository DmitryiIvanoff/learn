package Algotiyhms.Razdel1.Tema2.Zadanie5;

public class Queue {
    Object[] array;
    int top = -1;
    int first = 0, last = -1, elementCount = 0, maxSize;

    public Queue(int maxSize) {
        this.maxSize = maxSize;
        this.array = new Object[maxSize];
    }

    public int getLength() {
        return array.length;
    }

    public Object[] getArray() {
        return array;
    }

    public void add(Object e){

        if(this.hasEmptyCells()) {
            if (last == maxSize - 1) {
                last = 0;
            } else {
                last++;
            }
            array[last] = e;
            elementCount++;
        }
        else{
          System.out.println("Queue is full.");
        }

    }
    public Object peek(){
        return array[top];
    }

    public void remove() {
      if(elementCount > 0){
           array[first] = null;
           elementCount--;
           if(first < maxSize -1){
               first++;
           }
           else{
               first = 0;

           }
      }
      else{
          System.out.println("Queue is empty.");
      }
    }

    public boolean hasEmptyCells(){
        boolean isEmpty;
      if(elementCount < maxSize){
          isEmpty = true;
      }
      else {
           isEmpty = false;
      }
        return isEmpty;
    }

    public void view() {
        for(int i = 0; i < array.length; i++){
            System.out.print(array[i] + " ");
        }
        System.out.println();
    }

    public void emptyCheck(){
        if(top == -1){
            System.out.println("Очередь пуста");
        }
        else {
            System.out.println("Очередь непустая");
        }
    }

    public void fullCheck(){
        if(!hasEmptyCells()){
            System.out.println("Очередь заполнена");
        }
        else {
            System.out.println("Очередь не заполнена");
        }
    }

}
