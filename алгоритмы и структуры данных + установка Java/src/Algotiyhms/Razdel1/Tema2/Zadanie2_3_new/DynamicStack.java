package Algotiyhms.Razdel1.Tema2.Zadanie2_3_new;

public class DynamicStack {
    Element top;


    public void push(){
        Element newElement = new Element((int) (5000 * Math.random()));
        newElement.previous = this.top;
        top = newElement;

    }

    public void popSeveral(int number){
        for(int i = 0; i < number; i++){
         push();
        }
        view();
    }

    public void pop(){
     if(top != null) {
         if (top.previous != null) {
             this.top = top.previous;
         } else {
             top = null;
         }
         view();
     }
     else{
         System.out.println("Стек пуст");
     }

    }

    public void view(){
        Element temp = top;
        while (temp != null){
            System.out.print(temp.data + " ");
            temp = temp.previous;
        }
    }

    public void checkIsEmpty(){
        if(top == null){
            System.out.print("Стек пустой");
        }
        else {
            System.out.print("Стек не пустой");
        }
    }



}
