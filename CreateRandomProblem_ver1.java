import java.util.Scanner;
import java.util.Random;

public class CreateRandomProblem_ver1
{
    public static void main(String[] args)
    {
        Scanner sc = new Scanner(System.in);
        Random random = new Random();

        // 랜덤으로 나올 문제를 ""안에 직접 입력
        String[] problem = {
                "",
                /*
                 문제 추가 시
                "문제 내용 입력", <- 해당 내용을 추가하면 됨
                 */
        };

        //문제 랜덤으로 섞기
        for (int i = problem.length - 1; i >= 0; i--)
        {
            int newNumber = random.nextInt(i + 1);
            String temp = problem[i];
            problem[i] = problem[newNumber];
            problem[newNumber] = temp;
        }

        System.out.println("안녕하세요 내 맘대로 모의고사 프로그램에 오신 걸 환영합니다!");
        System.out.println("답안을 입력 후 [엔터 -> \"제출\" 입력 -> 엔터]를 하시면 다음 문제로 넘어갑니다.");
        System.out.println("그럼 파이팅 하시고 시험 꼭 만점 맞으세요 !");

        for (int i = 0; i < problem.length; i++)
        {
            System.out.println("-----------------------------------------------------------");
            System.out.println( i+1 + "번 문제 : " + problem[i]);
            System.out.print("답 : ");

            String answer = "";
            while (!answer.equals("제출"))
            {
                answer = sc.nextLine();
            }
        }
        System.out.println("모의고사가 종료되었습니다! 고생하셨어요!");
    }
}