package JavaCore.laba3_4;



public class Calculations {

    public static double calculateSin(double start, double end, double n , int precision){
        if(n == 0){
            throw new TrigonometricException("division by 0");
        }
        double step = (end - start) / (2 * precision);
        double fx1 = 0, fx2 = 0;

        for (int i = 1; i <= precision; i++){
            int z = 2 * i - 1;
            fx1 += Math.sin((start + z * step) / n);
        }

        for (int i = 1; i <= precision - 1; i++){
            int z = 2 * i;
            fx2 += Math.sin((start + z * step) / n);
        }

        return  (step / 3) * (Math.sin(start / n) + 4 * fx1 + 2 * fx2 + Math.sin((start + 2 * precision * step) / n));
    }

    public static double calculateCos(double start, double end, double n , int precision){
        if(n == 0){
            throw new TrigonometricException("division by 0");
        }
        double step = (end - start) / (2 * precision);
        double fx1 = 0, fx2 = 0;

        for (int i = 1; i <= precision; i++){
            int z = 2 * i - 1;
            fx1 += Math.cos((start + z * step) / n);
        }

        for (int i = 1; i <= precision - 1; i++){
            int z = 2 * i;
            fx2 += Math.cos((start + z * step) / n);
        }

        return  (step / 3) * (Math.cos(start / n) + 4 * fx1 + 2 * fx2 + Math.cos((start + 2 * precision * step) / n));
    }



    public static double calculateTan(double start, double end, double n , int precision){
        if(n == 0){
            throw new TrigonometricException("division by 0");
        }
        double step = (end - start) / (2 * precision);
        double fx1 = 0, fx2 = 0;

        for (int i = 1; i <= precision; i++){
            int z = 2 * i - 1;
            fx1 += Math.tan((start + z * step) / n);
        }

        for (int i = 1; i <= precision - 1; i++){
            int z = 2 * i;
            fx2 += Math.tan((start + z * step) / n);
        }

        return  (step / 3) * (Math.tan(start / n) + 4 * fx1 + 2 * fx2 + Math.tan((start + 2 * precision * step) / n));
    }


    public static double calculateCotan(double start, double end, double n , int precision){
        if(n == 0){
            throw new TrigonometricException("division by 0");
        }
        double step = (end - start) / (2 * precision);
        double fx1 = 0, fx2 = 0;

        for (int i = 1; i <= precision; i++){
            int z = 2 * i - 1;
            fx1 += Math.cos((start + z * step) / n) / Math.cos((start + z * step) / n);
        }

        for (int i = 1; i <= precision - 1; i++){
            int z = 2 * i;
            fx2 += Math.sin((start + z * step) / n) / Math.sin((start + z * step) / n);
        }

        return  (step / 3) * (cotangent(start / n) + 4 * fx1 + 2 * fx2 + cotangent((start + 2 * precision * step) / n));
    }

    public static double cotangent(double x){
        return Math.cos(x) / Math.sin(x);
    }
}
