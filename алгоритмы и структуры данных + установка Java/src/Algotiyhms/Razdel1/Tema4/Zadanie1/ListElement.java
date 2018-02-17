package Algotiyhms.Razdel1.Tema4.Zadanie1;

public class ListElement {
    protected ListElement next;
    protected ListElement previous;
    protected int data;
    protected int index;

    public ListElement(int data) {
        this.data = data;
    }

    public boolean hasNext(){
        if(this.next != null){
            return true;
        }
        else {
            return false;
        }
    }

    public boolean hasPrevious(){
        if(this.previous != null){
            return true;
        }
        else {
            return false;
        }
    }
}
