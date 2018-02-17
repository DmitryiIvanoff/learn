package Algotiyhms.Razdel1.Tema5.Zadanie1;

public class BinaryTree {
    static int treeSize;
    String tab = "";
    Node root;
    static int data;
    static int depth;
    static Node lastLeft;
    boolean flagForSearchLastLeft = false;


    public BinaryTree( int data) {
        this.data = data;
        this.root = new Node(0);
    }

    public void buildTree( int treeSize){
        for (int i = 0 ; i < treeSize; i ++){
            depth++;
            add(root);

        }
    }

    public Node add(Node node){
         if(node == null){
             node = new Node(++BinaryTree.data);
             node.depth = depth;
         } else{
                 node.left = add(node.left);
                 node.right = add(node.right);
         }
         return node;
    }


    public void traverseStraightDirection(Node node){
        if (node == null){
            return;
        }
        else{
            tab = enlargeDepth(node.depth);
            System.out.println(tab + node.data);
            traverseStraightDirection(node.left);
            traverseStraightDirection(node.right);
        }
    }



    public String enlargeDepth(int depth){
        String f = "";
        for (int i = 0; i < depth; i++){
            f += "     ";
        }
        return f;
    }

    public void traverseSymmetric(Node node){
        if (node == null){
            return;
        }
        else{

            traverseSymmetric(node.left);
            tab = enlargeDepth(node.depth);
            System.out.println(tab + node.data);
            traverseSymmetric(node.right);
        }
    }

    public void traverseReverseSymmetric(Node node){
        if (node == null){
            return;
        }
        else{
            traverseReverseSymmetric(node.right);
            tab = enlargeDepth(node.depth);
            System.out.println(tab + node.data);
            traverseReverseSymmetric(node.left);
        }
    }




    public Node lastLeft (Node node){

        if (node == null){
            flagForSearchLastLeft = true;
            return node;
        }
        else{
            lastLeft(node.left);
            if(flagForSearchLastLeft){
                lastLeft = node;
                flagForSearchLastLeft = false;
            }
        }
        return lastLeft;
    }





}
