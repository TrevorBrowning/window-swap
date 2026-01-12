# Window Swap

A small Windows utility written in C# that moves the currently active window to the other monitor and maximizes it.

This project uses the Windows (Win32) API via P/Invoke to:

- Detect the active (foreground) window
- Detect which monitor that window is on
- Enumerate all connected monitors

The long-term goal is a simple hotkey driven utility for quickly swapping windows between monitors.

---

## Current Features

- Detects the active window
- Detects the monitor the active window is on
- Enumerates all connected monitors
- Prints monitor bounds and layout information (for debugging)

---

## Planned Features

- Identify the “other” monitor automatically
- Move the active window to the other monitor
- Maximize the window after moving
- Optional hotkey support
- Package as a standalone `.exe`

---

## Tech Stack

- C#
- .NET 8
- Win32 API (`user32.dll`)
- Built with VS Code

---

## Status

Work in progress — early prototype stage.
