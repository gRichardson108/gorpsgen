using gorpsgen.Models;

namespace gorpsgen
{
    public class TestData
    {
        public static void loadTestData(QuizContext context)
        {
            var quiz = new Quiz {
                Title = "GORPSgen sample character quiz"
            };
            context.Quizzes.Add(quiz);
            context.SaveChanges();
            foreach (var question in testQuestions)
            {
                question.QuizId = quiz.ID;
                context.Questions.Add(question);
            }
            context.SaveChanges();
        }
        
        public static Question[] testQuestions = new Question[]
        {
            new Question {
                Text = "Question 1: On a clear day you chance upon a strange animal, its leg trapped in a hunter's clawsnare. Judging from the bleeding it will not survive long.",
                CombatAnswer = "Draw your dagger, mercifully ending its life with a single thrust.",
                MagicAnswer =  "Use herbs from your pack to put it to sleep.",
                StealthAnswer =  "Do not interfere in the natural evolution of events, but rather take the opportunity to learn more about a strange animal you have never seen before."
            },
            new Question {
                    Text = "Question 2: One Summer afternoon your father gives you a choice of chores.",
                    CombatAnswer = "Work in the forge with him casting iron for a new plow.",
                    MagicAnswer =  "Gather herbs for your mother who is preparing dinner.",
                    StealthAnswer =  "Go catch fish at the stream using a net and line."
                },
            new Question {
                    Text = "Question 3: Your cousin has given you a very embarrassing nickname and, even worse, likes to call you it in front of your friends. You asked him to stop, but he finds it very amusing to watch you blush.",
                    CombatAnswer = "Beat up your cousin, then tell him that if he ever calls you that nickname again, you will bloody him worse than this time.",
                    MagicAnswer =  "Make up a story that makes your nickname a badge of honor instead of something humiliating.",
                    StealthAnswer =  "Make up an even more embarrassing nickname for him and use it constantly until he learns his lesson."
                },
            new Question {
                    Text = "Question 4: There is a lot of heated discussion at the local tavern over a grouped of people called 'Telepaths'. They have been hired by certain City-State kings. Rumor has it these Telepaths read a person's mind and tell their lord whether a follower is telling the truth or not.",
                    CombatAnswer = "This is a terrible practice. A person's thoughts are his own and no one, not even a king, has the right to make such an invasion into another human's mind.",
                    MagicAnswer =  "Loyal followers to the king have nothing to fear from a Telepath. It is important to have a method of finding assassins and spies before it is too late.",
                    StealthAnswer =  "In these times, it is a necessary evil. Although you do not necessarily like the idea, a Telepath could have certain advantages during a time of war or in finding someone innocent of a crime."
                },
            new Question {
                    Text = "Question 5: Your mother sends you to the market with a list of goods to buy. After you finish you find that by mistake a shopkeeper has given you too much money back in exchange for one of the items.",
                    CombatAnswer = "Return to the store and give the shopkeeper his hard-earned money, explaining to him the mistake.",
                    MagicAnswer =  "Decide to put the extra money to good use and purchase items that would help your family.",
                    StealthAnswer =  "Pocket the extra money, knowing that shopkeepers in general tend to overcharge customers anyway."
                },
            new Question {
                    Text = "Question 6: While in the market place you witness a thief cut a purse from a noble. Even as he does so, the noble notices and calls for the city guards. In his haste to get away, the thief drops the purse near you. Surprisingly no one seems to notice the bag of coins at your feet.",
                    CombatAnswer = "Pick up the bag and signal to the guard, knowing that the only honorable thing to do is return the money to its rightful owner.",
                    MagicAnswer =  "Leave the bag there, knowing that it is better not to get involved.",
                    StealthAnswer =  "Pick up the bag and pocket it, knowing that the extra windfall will help your family in times of trouble."
                },
            new Question {
                    Text = "Question 7: Your father sends you on a task which you loathe, cleaning the stables. On the way there, pitchfork in hand, you run into your friend from the homestead near your own. He offers to do it for you, in return for a future favor of his choosing.",
                    CombatAnswer = "Decline his offer, knowing that your father expects you to do the work, and it is better not to be in debt.",
                    MagicAnswer =  "Ask him to help you, knowing that two people can do the job faster than one, and agree to help him with one task of his choosing in the future.",
                    StealthAnswer =  "Accept his offer, reasoning that as long as the stables are cleaned, it matters not who does the cleaning."
                },
            new Question {
                    Text = "Question 8: Your mother asks you to help fix the stove. While you are working, a very hot pipe slips its mooring and falls towards her.",
                    CombatAnswer = "Position yourself between the pipe and your mother.",
                    MagicAnswer =  "Grab the hot pipe and try to push it away.",
                    StealthAnswer =  "Push your mother out of the way."
                },
            new Question {
                    Text = "Question 9: While in town the baker gives you a sweetroll. Delighted, you take it into an alley to enjoy only to be intercepted by a gang of three other kids your age. The leader demands the sweetroll, or else he and his friends will beat you and take it.",
                    CombatAnswer = "Drop the sweetroll and step on it, then get ready for the fight.",
                    MagicAnswer =  "Give him the sweetroll now without argument, knowing that later this afternoon you will have all your friends with you and can come and take whatever he owes you.",
                    StealthAnswer =  "Act like you're going to give him the sweetroll, but at the last minute throw it in the air, hoping that they'll pay attention to it long enough for you to get a shot in on the leader."
                },
            new Question {
                    Text = "Question 10: Entering town you find that you are witness to a very well-dressed man running from a crowd. He screams to you for help. The crowd behind him seem very angry.",
                    CombatAnswer = "Rush to the town's aid immediately, despite your lack of knowledge of the circumstances.",
                    MagicAnswer =  "Stand aside and allow the man and the mob to pass, realizing it is probably best not to get involved.",
                    StealthAnswer =  "Rush to the man's aid immediately, despite your lack of knowledge of the circumstances."
                }
        };
    }
}