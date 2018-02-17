package Algotiyhms.Razdel1.Tema2.Zadanie1;

public class Stack {
    private int maxSize;
    private int top = -1;
    private int[] array;

    public Stack(int maxSize) {
        this.maxSize = maxSize;
        this.array = new int[maxSize];
    }

    public void pop() {
        if(top != -1){
            array[top--] = 0;
        }
        else{
            emptyCheck();
        }

    }

    public void  push(){
        if(top < maxSize - 1){
            top++;
            array[top] = (int) (5000 * Math.random());
        }
        else{
            fullCheck();
        }
    }



    public void emptyCheck(){
        if(top == -1){
            System.out.println("Стек пуст");
        }
        else {
            System.out.println("Стек непустой");
        }
    }

    public void fullCheck(){
        if(top == maxSize - 1){
            System.out.println("Стек полный");
        }
        else {
            System.out.println("Стек неполный");
        }
    }

    public void view() {
        for(int x: array){
            System.out.print(x + " ");
        }

        System.out.println();
    }
}
