import java.util.Scanner;
import java.util.Random;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class CreateRandomProblem_ver3
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
                "문제 내용", <- 해당 내용을 추가하면 됨
                 */
        };
        // 문제 배열의 순서와 답안 배열의 순서가 일치해야 함
        String[] correctAnswer = {
                "",
                /*
                 정답 추가 시
                "정답 내용", <- 해당 내용을 추가하면 됨
                 */
        };

        // 랜덤 숫자 생성
        List<Integer> newNumber = new ArrayList<>();
        for (int i = 0; i < problem.length; i++)
        {
            newNumber.add(i);
        }
        Collections.shuffle(newNumber);

        // 생성한 랜덤 숫자대로 문제 섞기
        for (int i = 0; i < problem.length; i++)
        {
            //문제 랜덤으로 섞기
            String tempProblem = problem[i];
            problem[i] = problem[newNumber.get(i)];
            problem[newNumber.get(i)] = tempProblem;
            //섞인 문제에 맞게 정답 매핑
            String tempCorrectAnswer = correctAnswer[i];
            correctAnswer[i] = correctAnswer[newNumber.get(i)];
            correctAnswer[newNumber.get(i)] = tempCorrectAnswer;
        }
        //문제 출력
        System.out.println("안녕하세요 도현이가 만든 모의고사 프로그램(ver.3)에 오신 걸 환영합니다!");
        System.out.println("답안을 입력 후 '엔터'를 하시면 다음 문제로 넘어갑니다.");
        System.out.println("그럼 파이팅 하시고 시험 꼭 만점 맞으세요 !");

        int score = 0;
        String[] myAnswer = new String[problem.length];
        int[] wrongNumber = new int[problem.length];
        for (int i = 0; i < problem.length; i++)
        {
            System.out.println("--------------------------------------------------------------------------------------------------------------------------------------------------------");
            System.out.println( i + 1 + "번 문제 : " + problem[i]);
            System.out.print("답 : ");
            myAnswer[i] = sc.nextLine();

            //결과 정보 저장
            if (myAnswer[i].equals(correctAnswer[i]))
                score += 1;
            else
                wrongNumber[i] = i+1;
        }
        //점수, 오답 출력
        System.out.println("--------------------------------------------------------------------------------------------------------------------------------------------------------");
        System.out.println("고생하셨어요! ^ㅁ^ \n점수 : " + score + "/" + problem.length);
        System.out.println("[틀린 문제들]");
        for (int i = 0; i < problem.length; i++)
        {
            if (wrongNumber[i] != 0)
            {
                System.out.println(wrongNumber[i] + "번 : " + problem[wrongNumber[i]-1]);
                System.out.println(myAnswer[wrongNumber[i]-1] + " (X) -> " + correctAnswer[wrongNumber[i]-1] + " (O)");
            }
        }
    }
}