package JavaCore.laba1_2.Part2;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class MainClass {

    public static void main(String[] args) throws IOException{
        BufferedReader bf = new BufferedReader(new InputStreamReader(System.in));
        String reader = "";
        double[] arrayOfAngles;
      //1-2  try {
        //    reader = bf.readLine();
      //  }
      //  catch(IOException e){
      //  }
        reader = "  7. 34        fd    ; ;;98  789 8 879 99 ,7 ,7,7,7gtg.6fgggggd55.fg34dfg11.1dfg fgd";
        WorkWithArray workWithArray = new WorkWithArray();
        arrayOfAngles = workWithArray.parseArrayDouble(reader);
        double d = WorkWithArray.getSumSinuses(arrayOfAngles, Integer.parseInt(args[0]), 6);
        System.out.println(d);





    }
}
