using UnityEngine;
using System.Collections;

public struct DialogueStruct
{
    public DialogueStruct(string _name, string _line, string _art, bool _allignmentRight)
    {
        name = _name;
        line = _line;
        art = _art;
        allignmentRight = _allignmentRight;
    }
    public string name;
    public string line;
    public string art;
    public bool allignmentRight;
}

public class DialogueData {
    public static string Wizcat = "Wizcat";
    public static string Ball = "Ball";
    public static string Mysterious = "??????";
    public static string UI = "Notification";

    /// <summary>
    /// Tutorial dialogue-----------------------------------------
    /// </summary>
    public static DialogueStruct[] tutorial1 = new DialogueStruct[]
    {
        new DialogueStruct(Wizcat, "Hello human. Or should I say ball…","Wizcat", false),
        new DialogueStruct(Wizcat, "You are stuck in the WizCat Nightmare","Wizcat",false),
        new DialogueStruct(Wizcat, "You’ll need to prove yourself worthy if you want to become the ultimate play ball...","Wizcat",false),
        new DialogueStruct(Wizcat, "EHM I MEAN if you want to get out! WHAHAHAHA!","laughingcat",false),
        new DialogueStruct(UI, "Tap and hold to move around.","none",false),
    };

    public static DialogueStruct[] tutorial2 = new DialogueStruct[]
    {
        new DialogueStruct(Mysterious, "You will need this if you want to stand any chance to end this nightmare.","mysterious",true),
        new DialogueStruct(Mysterious, "Be sure to take the lighter balls first!","mysterious",true),
        new DialogueStruct(UI, "You obtained the mass scanner!","none",false),
        new DialogueStruct(UI, "You can now see weight values of yourself and other entities.","none",false),
        new DialogueStruct(UI, "Make contact to interact with other balls.","none",false),
    };

    public static DialogueStruct[] tutorial3 = new DialogueStruct[]
    {
        new DialogueStruct(Mysterious, "I had to let you learn by yourself, didn’t I?","mysterious",true),
        new DialogueStruct(Mysterious, "Now go for the lighter balls first!","mysterious",true),
    };

    public static DialogueStruct[] tutorial4 = new DialogueStruct[]
    {
        new DialogueStruct(Wizcat, "How is it possible?!","Wizcat", false),
        new DialogueStruct(Wizcat, "It doesn't matter...","Wizcat", false),
        new DialogueStruct(Wizcat, "Your luck is not going to last forever...","Wizcat", false),
        new DialogueStruct(Wizcat, "In fact, abandon all your hope!","laughingcat", false),
    };

    /// <summary>
    /// Mainworld dialogue-----------------------------------------
    /// </summary>
    public static DialogueStruct[] mainWorld1 = new DialogueStruct[]
    {
        new DialogueStruct(Mysterious, "You might be wondering who I might be...","mysterious", false),
        new DialogueStruct(Mysterious, "I am in fact:....","mysterious", false),
        new DialogueStruct(Mysterious, "Just a farmer in this nightmare.","mysterious", false),
        new DialogueStruct(Mysterious, "To get out of here you must go to the mansion to your right and defeat the ultimate ball.","mysterious", false),
        new DialogueStruct(Mysterious, "And one last tip I can give to you:.","mysterious", false),
        new DialogueStruct(Mysterious, "'We're all math here!'","mysterious", false),
    };
    public static DialogueStruct[] mainWorld2 = new DialogueStruct[]
    {
        new DialogueStruct(Mysterious, "You might be wondering who I might be...","mysterious", false),
        new DialogueStruct(Mysterious, "I am in fact:....","mysterious", false),
        new DialogueStruct(Mysterious, "Just a farmer in this nightmare.","mysterious", false),
        new DialogueStruct(Mysterious, "To get out of here you must go to the mansion to your right and defeat the ultimate ball.","mysterious", false),
        new DialogueStruct(Mysterious, "And one last tip I can give to you:.","mysterious", false),
        new DialogueStruct(Mysterious, "'We're all math here!'","mysterious", false),
    };
}
