# Cyra Cyber Security Chatbot

 Overview

Cyra is a simple desktop cyber security chatbot built using **C#** and **WPF (Windows Presentation Foundation)**.
The chatbot provides basic cyber security awareness tips and answers common cyber-related questions.

The application includes:

* Interactive chatbot interface
* Predefined cyber security responses
* Chat history saving
* Voice greeting on startup
* Styled chat bubbles for user and bot messages

---

Features

 Cyber Security Assistance

The chatbot can answer questions about:

* Phishing
* SQL
* Home Wi-Fi safety
* Public Wi-Fi security
* Common phishing warning signs

 Chat History

All conversations are automatically saved to:

History/chat_history.txt

### Voice Greeting

The chatbot plays a greeting sound (`voice.wav`) when the application starts.

### Modern Chat Interface

* Bot messages appear on the left
* User messages appear on the right
* Timestamp for each message
* Styled message bubbles

---

## Technologies Used

* C#
* .NET WPF
* XAML
* Visual Studio

---

## Project Structure


WpfApp2/
│
├── MainWindow.xaml
├── MainWindow.xaml.cs
├── voice.wav
│
├── History/
│   └── chat_history.txt
│
└── README.md
```

---

## How to Run the Project

 Requirements

* Visual Studio 2019 or later
* .NET Framework / .NET SDK with WPF support

 Steps

1. Open the solution in Visual Studio
2. Build the project
3. Run the application

---

 Example Questions

You can ask the chatbot questions such as:

* "What is phishing?"
* "Tell me about home Wi-Fi security"
* "What is SQL?"
* "Hello"
* "What are typical warning signs of phishing?"

---

 Code Highlights

Response Dictionary

The chatbot uses a dictionary to store predefined responses:

```csharp
Dictionary<string, string> responses
```

 Saving Chat History

Messages are saved using:

```csharp
File.AppendAllText()
```

 Playing Audio Greeting

The chatbot uses:

```csharp
SoundPlayer
```

to play the greeting sound.

---

Future Improvements

Possible enhancements include:

* AI-powered responses
* Database integration
* User authentication
* More cyber security topics
* Speech-to-text support
* Dark mode UI
* Typing indicators

---

 Author

Developed as a WPF cyber security chatbot project using C#.

---

 License

This project is for educational purposes.
