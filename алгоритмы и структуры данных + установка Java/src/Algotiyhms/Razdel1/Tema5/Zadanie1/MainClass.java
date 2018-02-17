package Algotiyhms.Razdel1.Tema5.Zadanie1;

public class MainClass  {

    public static void main(String[] args) throws InterruptedException{
  BinaryTree tree = new BinaryTree( 0);

  tree.buildTree( 3);
  tree.traverseStraightDirection(tree.root);//пря
  System.out.println("=====================");
  tree.traverseSymmetric(tree.root);
  System.out.println("=====================");
  tree.traverseReverseSymmetric(tree.root);
    }
}
