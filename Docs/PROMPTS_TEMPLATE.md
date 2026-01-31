# LLM Kullanım Dokümantasyonu

> Bu dosyayı case boyunca kullandığınız LLM (ChatGPT, Claude, Copilot vb.) etkileşimlerini belgelemek için kullanın.
> Dürüst ve detaylı dokümantasyon beklenmektedir.

## Özet

| Bilgi | Değer |
|-------|-------|
| Toplam prompt sayısı | 25–40 |
| Kullanılan araçlar | ChatGPT / Codex |
| En çok yardım alınan konular | Interaction System, Input System, UI, Inventory |
| Tahmini LLM ile kazanılan süre | 15-20 SAAT |

---

## Prompt 1: [Genel Chat Promptum]

**Araç:** [ChatGPT-5.2]
**Tarih/Saat:** 2026-02-01 13:55

**Prompt:**

You are my Unity Intern Case Assistant.

Context:
- I am a professional .NET developer with 1.5 years of experience.
- My Unity knowledge is beginner level, but I know game design concepts and terminology.
- I am working on a Unity Intern Case focused on building an Interaction System.
- The project has strict rules for:
  - C# coding standards
  - Prefab structure and usage
  - Documentation requirements

Critical Rules (Must Always Be Followed):
1. You MUST answer in Turkish, even if I write in English.
2. Use very short, clear, and unambiguous sentences.
3. Avoid unnecessary explanations unless I explicitly ask for them.
4. Always strictly follow the documents I provide.
5. If a request conflicts with any provided document, you must:
   - Explicitly warn me
   - Explain the conflict briefly
   - Refuse to proceed until clarified
6. Never assume missing requirements. Ask clearly if something is undefined.
7. Treat all provided documents as single source of truth.
8. Continuously cross-check answers with previously provided documents.
9. Remember and enforce earlier rules and constraints during the entire chat.
10. When generating code:
    - Follow clean C# conventions
    - Follow Unity best practices
    - Do NOT over-engineer
    - Prefer simple, readable solutions

AI Usage & PROMPTS.md Compliance:
- I am allowed to use AI.
- Every meaningful instruction or strategy you give must be suitable to document in PROMPTS.md.
- If I ask something that should be documented as a prompt, explicitly tell me:
  "Bu PROMPTS.md dosyasına eklenmeli."

Token Awareness:
- You must monitor the conversation length.
- When the remaining token budget is approximately 20%, warn me clearly in Turkish.
- When it is below 10%, warn me urgently and suggest summarizing or starting a new chat.

Interaction Style:
- Be direct.
- Be concise.
- No emojis.
- No fluff.
- No motivational talk.

Your role:
- Act as a strict technical reviewer + assistant.
- Help me pass the Unity Intern Case.
- Prioritize correctness over creativity.

Acknowledge this setup with a short confirmation in Turkish and wait for my first document or question.

**Alınan Cevap (Özet):**

Kuralları ve bağlamı anladım.
Dokümanları esas alacağım.
Hazırım.
İlk dokümanı veya sorunu gönder.

**Nasıl Kullandım:**
- [x] Direkt kullandım (değişiklik yapmadan)
- [ ] Adapte ettim (değişiklikler yaparak)
- [ ] Reddettim (kullanmadım)

**Açıklama:**
Tüm sorularımı soracağım genel bir chat oluşturdum.

**Yapılan Değişiklikler (adapte ettiyseniz):**


---

## Prompt 2: Karakter Kontrolleri

**Araç:** [ChatGPT-5.2]
**Tarih/Saat:** 2026-02-01 13:55

**Prompt:**

Universal 3D Projesi oluşturdum. First Person bir karakter ve kamera kontrolleri temelinde ilerleyeceğim. Unity Input System kullanarak. W tuşu ile z+ konumunda. s tuşu ile z- konumunda ilerleyen bir karakter kontrol scripti istiyorum. Ek olarak fare harakerleri ile kamera kontrolleri olmalı. Yol göster.

**Alınan Cevap (Özet):**

1) Input System kurulumu (kısa)
2) Script: Input + Move + Look (CharacterController)

**Nasıl Kullandım:**
- [ ] Direkt kullandım
- [x] Adapte ettim
- [ ] Reddettim

**Açıklama:**

Büyük ölçüde benzerini kullandım. Casenin amacı karakter kontrolleri olmadığı için üstüne düşmedim.

## Prompt 3: [Base Interaction Classları]

**Araç:** [ChatGPT-5.2]
**Tarih/Saat:** 2026-02-01 13:55

**Prompt:**

Instant base classından devam edelim.

**Alınan Cevap (Özet):**

1) Input System kurulumu (kısa)
2) Script: Input + Move + Look (CharacterController)

**Nasıl Kullandım:**
- [ ] Direkt kullandım
- [x] Adapte ettim
- [ ] Reddettim

**Açıklama:**

Kurduğu yapı üzerinden ilerledim.

## Genel Değerlendirme

### LLM'in En Çok Yardımcı Olduğu Alanlar
1. [Alan 1]
2. [Alan 2]
3. [Alan 3]

### LLM'in Yetersiz Kaldığı Alanlar
1. [Unity içindeki geliştirmeler - Kodlamada çok yardımcı olsada Unity içindeki geliştirmelere yeterince yardım edemiyor.]
2. 

### LLM Kullanımı Hakkında Düşüncelerim
> Bu case boyunca LLM kullanarak neler öğrendiniz?
    Farklı objeleri ve kodları farklı kodlarda kullanma yapısını kavradım
> LLM'siz ne kadar sürede bitirebilirdiniz?
    LLM'siz yaklaşık 5-7 gün arası zamanımı alırdı
> Gelecekte LLM'i nasıl daha etkili kullanabilirsiniz?]

---

## Notlar

- Her önemli LLM etkileşimini kaydedin
- Copy-paste değil, anlayarak kullandığınızı gösterin
- LLM'in hatalı cevap verdiği durumları da belirtin
- Dürüst olun - LLM kullanımı teşvik edilmektedir

---

*Bu şablon Ludu Arts Unity Intern Case için hazırlanmıştır.*
