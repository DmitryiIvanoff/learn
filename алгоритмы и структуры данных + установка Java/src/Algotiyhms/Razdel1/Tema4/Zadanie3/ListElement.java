package Algotiyhms.Razdel1.Tema4.Zadanie3;

public class ListElement {
    ListElement next;
    ListElement previous;
    int data;
    int index;

    public ListElement(int data) {
        this.data = data;
    }

    public boolean hasNext(){
        if(this.next != null){
            return true;
        } else {
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
