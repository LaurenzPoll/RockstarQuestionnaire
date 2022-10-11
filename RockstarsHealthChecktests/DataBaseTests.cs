﻿using RockstarsHealthCheck.Models;

namespace RockstarsHealthCheckTests;

public class DataBaseTests
{
    [Fact]
    private void Can_we_add_data_to_table_and_read_it()
    {
        var _dataBase = new DataBase();

        _dataBase.AddQuestionToDataBase(2, "3+1", "Test");

        List<Question> questions = _dataBase.GetQuestionsFromQuestionnaire(2, "test");
        foreach (Question question in questions)
        {
            Assert.Equal(2, question.QuestionaireId);
            Assert.Equal("3+1", question.QuestionString);
        }

        _dataBase.DeleteEverythingFromTable("Test");
    }

    [Fact]
    private void Can_we_clear_an_entire_table()
    {
        var _dataBase = new DataBase();
        for (int i = 0; i < 10; i++)
            _dataBase.AddQuestionToDataBase(i, "1+1", "Test");

        _dataBase.DeleteEverythingFromTable("Test");

        List<Question> questions = _dataBase.GetAllQuestionsFromDataBase("Test");
        Assert.Empty(questions);
    }

    [Fact]
    private void Do_we_get_the_right_data_from_the_table()
    {
        DataBase _dataBase = new DataBase();
        _dataBase.AddQuestionToDataBase(2, "3+1", "Test");
        _dataBase.AddQuestionToDataBase(3, "4+1", "Test");

        List<Question> questions = _dataBase.GetQuestionsFromQuestionnaire(2, "Test");

        foreach (Question question in questions)
        {
            Assert.Equal(2, question.QuestionaireId);
        }

        _dataBase.DeleteEverythingFromTable("Test");
    }
}
