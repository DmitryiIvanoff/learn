package Algotiyhms.Razdel1.Tema4.Zadanie1;

public class LinkedList {
 private ListElement head;
 private ListElement tail;
 public static final String backward = "BACKWARD", forward = "FORWARD";


   public void add(int data){
       ListElement newElement = new ListElement(data);
       if(tail == null){
           head = newElement;
           tail = newElement;
           head.index = 0;
        //   head.previous = tail; //чтобы стал кольцевым
       }
       else
       {
           int count = tail.index + 1;
           tail.next = newElement;
           ListElement temp = tail;
           tail = newElement;
           tail.previous = temp;
           tail.index = count;

       //    tail.next = head; //чтобы стал кольцевым
       }
   }

   public void add(int data, int index){
       ListElement newElement = new ListElement(data);
       if(tail == null){
           newElement.index = 0;
           head = newElement;
           tail = newElement;

       }
       else{
           ListElement temp = head;
           ListElement saveNextIndex;

           if(tail.index + 1 == index ){
               saveNextIndex = tail;
               tail = newElement;
               tail.previous = saveNextIndex;
               saveNextIndex.next = tail;
               tail.index = saveNextIndex.index + 1;
           }
           else {
               do {
                   if(index == 0){   //вставка в начало списка
                       saveNextIndex = head;
                       head = newElement;
                       newElement.next = saveNextIndex;
                       saveNextIndex.previous = newElement;
                       saveNextIndex.index++;
                       while (temp.hasNext()){
                           temp = temp.next;
                           temp.index++;
                       }
                       break;
                   }

                   if(temp.index == index - 1){ //останавливаемся на элементе, предществующему значению  listIndex
                       saveNextIndex = temp.next; //сохраняем во временную ссылку значение ссылки на объект listIndex
                       //  ListElement savePreviousIndex = temp.next.previous;   //temp.next.previous - ссылка previous listIndex элемента
                       temp.next.previous = newElement;
                       temp.next = newElement; //
                       temp.next.index = index;
                       newElement.next = saveNextIndex;
                       newElement.previous = temp;

                       temp = temp.next;
                       while (temp.hasNext()){
                           temp = temp.next;
                           temp.index++;
                       }
                       break;
                   }
                   temp = temp.next;
               }
               while (temp.hasNext());
           }
          // tail.index++;
       }


   }

   public void delete(int index){
       if(head != null ){
           ListElement temp = head;
           if(index <= tail.index) {
               if(head == tail){
                   head = null;
               }
               while (temp.hasNext()) {
                   if (index == 0) {
                       head = temp.next;
                       head.previous = null;

                       while (temp.hasNext()) {
                           temp = temp.next;
                           temp.index--;
                       }
                       break;
                   } else {
                       if (temp.index == index - 1) {
                           temp.next = temp.next.next;
                           temp.next.previous = temp;

                           while (temp.hasNext()) {
                               temp = temp.next;
                               temp.index--;
                           }
                           break;
                       }

                   }
                   temp = temp.next;
               }

           }
           else System.out.println("OutOfIndex");
           }
           else{
           System.out.println("LinkedList is hasEmptyCells");
       }

       }


   public void printList(){
       if(head != null) {
           System.out.println(head.data + " index = " + head.index);
           ListElement f = head;
           while (f.hasNext()) {
               f = f.next;
               System.out.println(f.data + " index = " + f.index);
           }
       }
       else{
           System.out.println("LinkedList is hasEmptyCells");
       }

   }

    public void printListBackward(){
        if(head != null) {
            System.out.println(tail.data + " index = " + tail.index);
            ListElement f = tail;
          do  {
                f = f.previous;
                System.out.println(f.data + " index = " + f.index);
            } while (f.hasPrevious());
        }
        else{
            System.out.println("LinkedList is hasEmptyCells");
        }
    }


    public void search(String choice, int key ) {
        if (head != null) {
            if (choice.equals(forward)) {
                ListElement f = head;
                while (f.hasNext()) {
                    if (f.data == key ) {
                        System.out.println(f.data + " index = " + f.index);
                        break;
                    } else {

                        f = f.next;
                    }
                }
                if(tail.data == key){
                    System.out.println(tail.data + " index = " + tail.index);
                }
            } else {
                if (choice.equals(backward)) {
                    ListElement f = tail;
                    while (f.hasPrevious()) {
                        if (f.data == key) {
                            System.out.println(f.data + " index = " + f.index);
                            break;
                        } else {
                            f = f.previous;
                        }
                    }
                    if(head.data == key){
                        System.out.println(head.data + " index = " + head.index);
                    }
                }
            }

        }
        else{
            System.out.println("LinkedList is hasEmptyCells");
        }
    }

}
