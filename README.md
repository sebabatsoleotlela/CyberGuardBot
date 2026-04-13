# CyberGuardBot
Technical Documentation and User Guide

## Overview
CyberGuardBot is a C# console-based application designed for cybersecurity education. The program provides a modular interface for users to learn about password security, phishing prevention, and general digital safety.

## System Architecture
The application is built using a modular object-oriented approach:

* **Program.cs**: Manages the main application lifecycle, user input loops, and console UI rendering.
* **ChatBrain.cs**: Contains the logic engine for intent recognition, keyword processing, and the alternating response system.
* **Multimedia.cs**: Handles external asset integration including JPEG-to-ASCII conversion and audio playback.
* **User.cs**: Encapsulates user session data.

## Features
* **Intent Recognition**: Processes conversational queries regarding the bot's purpose and general help.
* **Knowledge Base**: Specialized response sets for Passwords, Phishing, and Security.
* **Asset Handling**: Dynamic pathing for external .jpg and .wav files.
* **Iterative Responses**: Index tracking to provide varied responses for repetitive queries.

## Installation and Execution
1. Open the solution in Visual Studio 2022.
2. Verify that `logo.jpg` and `greet.wav` are present in the target output directory (/bin/Debug/net8.0/).
3. Build the solution (Ctrl+Shift+B).
4. Run the application (F5).

## Interaction Guide
The bot responds to specific keywords and phrases:
* "What is your purpose?"
* "Password"
* "Phishing"
* "Security"
* "Exit" (Terminates the session)
