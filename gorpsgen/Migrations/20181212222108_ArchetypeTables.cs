using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gorpsgen.Migrations
{
    public partial class ArchetypeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Archetypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BaseStrength = table.Column<int>(nullable: false),
                    BaseDexterity = table.Column<int>(nullable: false),
                    BaseIntelligence = table.Column<int>(nullable: false),
                    BaseHealth = table.Column<int>(nullable: false),
                    CombatRating = table.Column<int>(nullable: false),
                    MagicRating = table.Column<int>(nullable: false),
                    StealthRating = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archetypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "QuizResponses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RatioCombat = table.Column<int>(nullable: false),
                    RatioMagic = table.Column<int>(nullable: false),
                    RatioStealth = table.Column<int>(nullable: false),
                    QuizID = table.Column<int>(nullable: false),
                    UserSub = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizResponses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QuizResponses_Quizzes_QuizID",
                        column: x => x.QuizID,
                        principalTable: "Quizzes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSheets",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Strength = table.Column<int>(nullable: false),
                    Dexterity = table.Column<int>(nullable: false),
                    Intelligence = table.Column<int>(nullable: false),
                    Health = table.Column<int>(nullable: false),
                    ArchetypeID = table.Column<int>(nullable: false),
                    UserSub = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSheets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CharacterSheets_Archetypes_ArchetypeID",
                        column: x => x.ArchetypeID,
                        principalTable: "Archetypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BaseStat = table.Column<string>(nullable: true),
                    Difficulty = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CharacterSheetID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Skills_CharacterSheets_CharacterSheetID",
                        column: x => x.CharacterSheetID,
                        principalTable: "CharacterSheets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArchetypeSkills",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ArchetypeID = table.Column<int>(nullable: false),
                    SkillID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchetypeSkills", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ArchetypeSkills_Archetypes_ArchetypeID",
                        column: x => x.ArchetypeID,
                        principalTable: "Archetypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArchetypeSkills_Skills_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skills",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSkills",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SkillID = table.Column<int>(nullable: false),
                    CharacterSheetID = table.Column<int>(nullable: false),
                    PointsInvested = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSkills", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CharacterSkills_CharacterSheets_CharacterSheetID",
                        column: x => x.CharacterSheetID,
                        principalTable: "CharacterSheets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSkills_Skills_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skills",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Archetypes",
                columns: new[] { "ID", "BaseDexterity", "BaseHealth", "BaseIntelligence", "BaseStrength", "CombatRating", "MagicRating", "Name", "StealthRating" },
                values: new object[,]
                {
                    { 1, 11, 12, 9, 14, 7, 0, "Warrior", 0 },
                    { 2, 11, 10, 14, 9, 0, 7, "Mage", 0 },
                    { 3, 13, 10, 11, 10, 0, 0, "Thief", 7 },
                    { 4, 10, 10, 10, 10, 0, 0, "Peasant", 0 }
                });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "ID", "Title" },
                values: new object[] { 1, "Sample character quiz" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "ID", "BaseStat", "CharacterSheetID", "Difficulty", "Name" },
                values: new object[,]
                {
                    { 1, "DX", null, "Average", "Long Blade" },
                    { 2, "DX", null, "Average", "Short Blade" },
                    { 3, "DX", null, "Average", "Archery" },
                    { 4, "INT", null, "Hard", "Conjuration" },
                    { 5, "INT", null, "Hard", "Mysticism" },
                    { 6, "INT", null, "Easy", "First Aid" }
                });

            migrationBuilder.InsertData(
                table: "ArchetypeSkills",
                columns: new[] { "ID", "ArchetypeID", "SkillID" },
                values: new object[,]
                {
                    { 9, 1, 6 },
                    { 4, 2, 5 },
                    { 3, 2, 4 },
                    { 6, 3, 3 },
                    { 7, 4, 2 },
                    { 5, 3, 2 },
                    { 2, 1, 2 },
                    { 1, 1, 1 },
                    { 8, 4, 6 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "ID", "CombatAnswer", "MagicAnswer", "QuizId", "StealthAnswer", "Text" },
                values: new object[,]
                {
                    { 10, "Rush to the town's aid immediately, despite your lack of knowledge of the circumstances.", "Stand aside and allow the man and the mob to pass, realizing it is probably best not to get involved.", 1, "Rush to the man's aid immediately, despite your lack of knowledge of the circumstances.", "Question 10: Entering town you find that you are witness to a very well-dressed man running from a crowd. He screams to you for help. The crowd behind him seem very angry." },
                    { 8, "Position yourself between the pipe and your mother.", "Grab the hot pipe and try to push it away.", 1, "Push your mother out of the way.", "Question 8: Your mother asks you to help fix the stove. While you are working, a very hot pipe slips its mooring and falls towards her." },
                    { 7, "Decline his offer, knowing that your father expects you to do the work, and it is better not to be in debt.", "Ask him to help you, knowing that two people can do the job faster than one, and agree to help him with one task of his choosing in the future.", 1, "Accept his offer, reasoning that as long as the stables are cleaned, it matters not who does the cleaning.", "Question 7: Your father sends you on a task which you loathe, cleaning the stables. On the way there, pitchfork in hand, you run into your friend from the homestead near your own. He offers to do it for you, in return for a future favor of his choosing." },
                    { 6, "Pick up the bag and signal to the guard, knowing that the only honorable thing to do is return the money to its rightful owner.", "Leave the bag there, knowing that it is better not to get involved.", 1, "Pick up the bag and pocket it, knowing that the extra windfall will help your family in times of trouble.", "Question 6: While in the market place you witness a thief cut a purse from a noble. Even as he does so, the noble notices and calls for the city guards. In his haste to get away, the thief drops the purse near you. Surprisingly no one seems to notice the bag of coins at your feet." },
                    { 5, "Return to the store and give the shopkeeper his hard-earned money, explaining to him the mistake.", "Decide to put the extra money to good use and purchase items that would help your family.", 1, "Pocket the extra money, knowing that shopkeepers in general tend to overcharge customers anyway.", "Question 5: Your mother sends you to the market with a list of goods to buy. After you finish you find that by mistake a shopkeeper has given you too much money back in exchange for one of the items." },
                    { 4, "This is a terrible practice. A person's thoughts are his own and no one, not even a king, has the right to make such an invasion into another human's mind.", "Loyal followers to the king have nothing to fear from a Telepath. It is important to have a method of finding assassins and spies before it is too late.", 1, "In these times, it is a necessary evil. Although you do not necessarily like the idea, a Telepath could have certain advantages during a time of war or in finding someone innocent of a crime.", "Question 4: There is a lot of heated discussion at the local tavern over a grouped of people called 'Telepaths'. They have been hired by certain City-State kings. Rumor has it these Telepaths read a person's mind and tell their lord whether a follower is telling the truth or not." },
                    { 3, "Beat up your cousin, then tell him that if he ever calls you that nickname again, you will bloody him worse than this time.", "Make up a story that makes your nickname a badge of honor instead of something humiliating.", 1, "Make up an even more embarrassing nickname for him and use it constantly until he learns his lesson.", "Question 3: Your cousin has given you a very embarrassing nickname and, even worse, likes to call you it in front of your friends. You asked him to stop, but he finds it very amusing to watch you blush." },
                    { 2, "Work in the forge with him casting iron for a new plow.", "Gather herbs for your mother who is preparing dinner.", 1, "Go catch fish at the stream using a net and line.", "Question 2: One Summer afternoon your father gives you a choice of chores." },
                    { 9, "Drop the sweetroll and step on it, then get ready for the fight.", "Give him the sweetroll now without argument, knowing that later this afternoon you will have all your friends with you and can come and take whatever he owes you.", 1, "Act like you're going to give him the sweetroll, but at the last minute throw it in the air, hoping that they'll pay attention to it long enough for you to get a shot in on the leader.", "Question 9: While in town the baker gives you a sweetroll. Delighted, you take it into an alley to enjoy only to be intercepted by a gang of three other kids your age. The leader demands the sweetroll, or else he and his friends will beat you and take it." },
                    { 1, "Draw your dagger, mercifully ending its life with a single thrust.", "Use herbs from your pack to put it to sleep.", 1, "Do not interfere in the natural evolution of events, but rather take the opportunity to learn more about a strange animal you have never seen before.", "Question 1: On a clear day you chance upon a strange animal, its leg trapped in a hunter's clawsnare. Judging from the bleeding it will not survive long." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchetypeSkills_ArchetypeID",
                table: "ArchetypeSkills",
                column: "ArchetypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ArchetypeSkills_SkillID",
                table: "ArchetypeSkills",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSheets_ArchetypeID",
                table: "CharacterSheets",
                column: "ArchetypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSkills_CharacterSheetID",
                table: "CharacterSkills",
                column: "CharacterSheetID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSkills_SkillID",
                table: "CharacterSkills",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_QuizResponses_QuizID",
                table: "QuizResponses",
                column: "QuizID");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CharacterSheetID",
                table: "Skills",
                column: "CharacterSheetID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchetypeSkills");

            migrationBuilder.DropTable(
                name: "CharacterSkills");

            migrationBuilder.DropTable(
                name: "QuizResponses");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "CharacterSheets");

            migrationBuilder.DropTable(
                name: "Archetypes");

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
