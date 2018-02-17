package Algotiyhms.Razdel1.Tema3.Zadanie4;

public class List {
 ListElement head;
 ListElement tail;

   public void add(int data){
       ListElement newElement = new ListElement(data);
       if(tail == null){
           head = newElement;
           tail = newElement;
           head.index = 0;
       }
       else
       {
           int count = tail.index + 1;
           tail.next = newElement;
           tail = newElement;
           tail.index = count;
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
           while (temp.hasNext()){
               if(index == 0){
                   saveNextIndex = head;
                   head = newElement;
                   newElement.next = saveNextIndex;
                   saveNextIndex.index++;
                   while (temp.hasNext()){
                       temp = temp.next;
                       temp.index++;
                   }
                   break;
               }
               if(temp.index == index - 1){
                   saveNextIndex = temp.next;
                   temp.next = newElement;
                   temp.next.index = index;
                   newElement.next = saveNextIndex;
                  temp = temp.next;
                   while (temp.hasNext()){
                       temp = temp.next;
                       temp.index++;
                   }
                   break;
               }
               temp = temp.next;
           }
       }
   }

   public void remove(int index){
if(tail != null){
           ListElement temp = head;
           while (temp.hasNext()) {
               if(index == 0){
                   head = temp.next;
                   while (temp.hasNext()){
                       temp = temp.next;
                       temp.index--;
                   }
                   break;
               }
               if(index == tail.index){
                   if(temp.next.index == index ){
                       temp.next = null;
                       tail = temp;
                       break;
                   }
                   else {
                       temp = temp.next;
                       continue;
                   }
               }
               if(temp.index == index - 1) {
                   temp.next = temp.next.next;
                   while (temp.hasNext()){
                       temp = temp.next;
                       temp.index--;
                   }
                   break;
               }
               temp = temp.next;
           }
           }
       }


   public void printList(){
if(tail != null) {
           System.out.println(head.data + " index = " + head.index);
           ListElement f = head;
           while (f.hasNext()) {
               f = f.next;
               System.out.println(f.data + " index = " + f.index);
           }
       }

   }


}
