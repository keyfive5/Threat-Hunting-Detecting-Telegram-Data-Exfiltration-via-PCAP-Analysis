# Threat Hunting: Detecting Telegram Data Exfiltration via PCAP Analysis

## 📌 Overview
This project demonstrates a hands-on **threat hunting investigation** using PCAP analysis to identify malicious activity within network traffic.

The focus of this case study is detecting **data exfiltration via the Telegram Bot API**, a technique commonly used by attackers to blend malicious traffic with legitimate encrypted communication.

---

## 🎯 Objective
- Analyze network traffic to identify suspicious behavior  
- Determine if a host is compromised  
- Investigate potential data exfiltration  
- Develop detection insights based on observed attacker activity  

---

## 🧠 Threat Hunting Context
Threat hunting is a **proactive process of searching for hidden threats** in a system rather than waiting for alerts. :contentReference[oaicite:0]{index=0}  

This project follows that mindset by assuming compromise and actively investigating abnormal traffic patterns.

---

## 🔍 Key Findings

- **Compromised Host:** 192.168.100.7  
- **Destination:** api.telegram.org (149.154.167.220)  
- **Protocol:** HTTPS (TLS encrypted)  
- **Exfiltration Method:** Telegram Bot API (`/sendMessage`)  
- **Data Format:** JSON (`application/json`)  

### 🚨 Suspicious Behavior Identified
- Repeated DNS queries to Telegram infrastructure  
- Encrypted HTTPS sessions to Telegram API  
- HTTP POST requests sending structured data  
- Use of Telegram bot token for communication  

Telegram Bot API is frequently abused by attackers for command-and-control (C2) and data exfiltration because it operates over HTTPS and blends into normal traffic. :contentReference[oaicite:1]{index=1}  

---

## 🧪 Analysis Workflow

1. Loaded PCAP file into Wireshark  
2. Filtered traffic using: ip.addr == 149.154.167.0/24
3. Identified suspicious TLS sessions  
4. Decrypted HTTPS traffic using SSL key log  
5. Inspected HTTP streams  
6. Detected POST requests to Telegram Bot API  
7. Confirmed data exfiltration behavior  

---

## ⚔️ Attacker Techniques Observed

- **Command & Control (C2):** Communication via Telegram API  
- **Encrypted Exfiltration:** HTTPS/TLS used to evade detection  
- **Living off Legitimate Services:** Abuse of trusted platform (Telegram)  
- **Script-Based Execution:** Evidence of PowerShell usage  

These techniques align with real-world attacker behavior where legitimate services are used to avoid detection.

---

## 🛠️ Tools & Technologies

- Wireshark  
- PCAP Analysis  
- TLS Decryption (SSL Key Log)  
- Suricata (Detection Rules)  
- Flowsynth (Traffic Simulation)  

---

## 🧬 Detection Engineering

A Suricata rule was developed to detect exploitation attempts related to:

- **CVE-2025-6771 (Ivanti EPMM RCE)**  
- Malicious HTTP POST requests  
- Command injection patterns  

Additionally, simulated attack traffic was generated using Flowsynth to validate detection logic.

---

## 🧪 Traffic Simulation

Flowsynth was used to:
- Simulate exploit traffic  
- Recreate attacker behavior  
- Test detection rules against crafted scenarios  

This demonstrates the ability to go beyond analysis and **validate detection mechanisms**.

---

## 📁 Repository Structure
.
├── data/
│ └── 21.pcap
├── rules/
│ └── suricata.rules
├── simulation/
│ └── cve2025.fs
├── report/
│ └── Threat_Hunting_Telegram_Exfiltration_Case_Study.pdf
├── screenshots/
│ └── analysis.png
└── README.md

---

## 🔐 Detection Opportunities

- Monitor outbound connections to `api.telegram.org`  
- Detect abnormal HTTPS POST patterns  
- Flag use of Telegram Bot API endpoints (`/bot*/sendMessage`)  
- Monitor scripting engines (e.g., PowerShell) making external connections  

---

## 🧾 Conclusion

This investigation confirms that a compromised host was used to **exfiltrate data via the Telegram Bot API over encrypted HTTPS**.

The project highlights:
- The importance of analyzing encrypted traffic  
- How attackers abuse legitimate services  
- The value of proactive threat hunting  

---

## ⚠️ Dataset Notice
The data used in this project is for **educational and research purposes only**.  
No sensitive or personal information was intentionally included.

---

## 🚀 Key Takeaway
Threat hunting is not about waiting for alerts — it’s about:
> **thinking like an attacker and proving whether they are present.**

---

## 👤 Author
Hasan Zafar  
Cybersecurity Graduate | Threat Hunting | Network Analysis
