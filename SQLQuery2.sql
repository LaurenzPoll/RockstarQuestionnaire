CREATE TABLE Users(
    UserID int IDENTITY(1,1) PRIMARY KEY,
    Email varchar not NULL
)

CREATE TABLE Questionnaires(
    QuestionnaireID int IDENTITY(1,1) PRIMARY KEY,
    QuestionnaireName VARCHAR not NULL,
    QuestionnaireLink VARCHAR not NULL
)

CREATE TABLE Questions(
    QuestionID int IDENTITY(1,1) PRIMARY KEY,
    QuestionnaireID int FOREIGN KEY REFERENCES Questionnaires(QuestionnaireID),
    Question VARCHAR
)

CREATE TABLE Answers(
    UserID int FOREIGN KEY REFERENCES Users(UserID),
    QuestionID int FOREIGN KEY REFERENCES Questions(QuestionID),
    Answer VARCHAR,
    AnswerRange int not NULL,
)

CREATE TABLE Admin(
    AdminID int IDENTITY(1,1) PRIMARY KEY,
    Email varchar not NULL,
    Password varchar not NULL
)


CREATE TABLE HelloWorld(
    DateID int IDENTITY(1,1) PRIMARY KEY,
    DateTime varchar not NULL,
)

ALTER TABLE HelloWorld ALTER COLUMN DateTime VARCHAR (500) NOT NULL;