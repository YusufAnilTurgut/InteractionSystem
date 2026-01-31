# Interaction System - Yusuf Anıl Turgut
> Ludu Arts Unity Developer Intern Case

Zaman eksikliğinden dolayı dokümanlar yeterince ayrıntılı doldurulamamıştır.

## Proje Bilgileri

| Bilgi | Değer |
|-------|-------|
| Unity Versiyonu | 6000.3.0f1 |
| Render Pipeline | Built-in / URP / HDRP |
| Case Süresi | 12 saat |
| Tamamlanma Oranı |  |

---

## Kurulum

1. Repository'yi klonlayın:
```bash
git clone https://github.com/YusufAnilTurgut/InteractionSystem.git
```

2. Unity Hub'da projeyi açın
3. `Assets/InteractionSystem/Scenes/TestScene.unity` sahnesini açın
4. Play tuşuna basın

---

## Nasıl Test Edilir

### Kontroller

| Tuş | Aksiyon |
|-----|---------|
| WASD | Hareket |
| Mouse | Bakış yönü |
| E | Etkileşim |


### Test Senaryoları

1. **Door Test:**
   - Kapıya yaklaşın,
   - E'ye basın, kapı açılsın
   - Tekrar basın, kapı kapansın

2. **Key + Locked Door Test:**
   - Kilitli kapıya yaklaşın,
   - Anahtarı bulun ve toplayın
   - Kilitli kapıya geri dönün, şimdi açılabilir olmalı

3. **Switch Test:**
   - Switch'e yaklaşın ve aktive edin

4. **Chest Test:**
   - Sandığa yaklaşın
   - E'ye basılı tutun, progress bar dolsun
   - Sandık açılsı

---

## Mimari Kararlar

### Interaction System Yapısı


**Neden bu yapıyı seçtim:**

**Alternatifler:**

**Trade-off'lar:**

### Kullanılan Design Patterns


## Ludu Arts Standartlarına Uyum

### C# Coding Conventions

| Kural | Uygulandı | Notlar |
|-------|-----------|--------|
| m_ prefix (private fields) | [] / [x] | |
| s_ prefix (private static) | [] / [x] | |
| k_ prefix (private const) | [] / [x] | |
| Region kullanımı | [] / [x] | |
| Region sırası doğru | [x] / [x] | |
| XML documentation | [x] / [ ] | |
| Silent bypass yok | [x] / [ ] | |
| Explicit interface impl. | [x] / [ ] | |

### Naming Convention

| Kural | Uygulandı | Örnekler |
|-------|-----------|----------|
| P_ prefix (Prefab) | [] / [x] | P_Door, P_Chest |
| M_ prefix (Material) | [x] / [ ] | M_Door_Wood |
| T_ prefix (Texture) | [x] / [ ] | |
| SO isimlendirme | [] / [x] | |

### Prefab Kuralları

| Kural | Uygulandı | Notlar |
|-------|-----------|--------|
| Transform (0,0,0) | [x] / [ ] | |
| Pivot bottom-center | [x] / [ ] | |
| Collider tercihi | [x] / [ ] | Box > Capsule > Mesh |
| Hierarchy yapısı | [x] / [ ] | |

### Zorlandığım Noktalar
> [Standartları uygularken zorlandığınız yerler]

---

## Tamamlanan Özellikler

### Zorunlu (Must Have)

- [] / [x] Core Interaction System
  - [] / [x] IInteractable interface
  - [] / [x] InteractionDetector
  - [] / [x] Range kontrolü

- [] / [x] Interaction Types
  - [] / [x] Instant
  - [] / [x] Hold
  - [] / [x] Toggle

- [x] / [ ] Interactable Objects
  - [] / [ x] Door (locked/unlocked)
  - [x] / [ ] Key Pickup
  - [] / [x] Switch/Lever
  - [x] / [x] Chest/Container

- [x] / [ ] UI Feedback
  - [] / [ ] Interaction prompt
  - [] / [ ] Dynamic text
  - [x] / [x] Hold progress bar
  - [] / [ ] Cannot interact feedback

- [] / [x] Simple Inventory
  - [] / [x] Key toplama
  - [] / [x] UI listesi

### Bonus (Nice to Have)

- [ ] Animation entegrasyonu
- [ ] Sound effects
- [ ] Multiple keys / color-coded
- [ ] Interaction highlight
- [ ] Save/Load states
- [ ] Chained interactions

---

## Bilinen Limitasyonlar

### Tamamlanamayan Özellikler
1. [Özellik] - [Neden tamamlanamadı]
2. [Key Sistem] - [Zaman yeterli olmadı]

### Bilinen Bug'lar

### İyileştirme Önerileri

---

## Ekstra Özellikler


## Dosya Yapısı

```
Assets/
├── [ProjectName]/
│   ├── Scripts/
│   │   ├── Runtime/
│   │   │   ├── Core/
│   │   │   │   ├── IInteractable.cs
│   │   │   │   └── HoldInterctableBase.cs
│   │   │   │   └── InstantInterctableBase.cs
│   │   │   │   └── InteractableBase.cs
│   │   │   │   └── SwitchInterctableBase.cs
│   │   │   ├── Interactables/
│   │   │   │   ├── Door.cs
│   │   │   │   └── Chest.cs
│   │   │   │   └── Key.cs
│   │   │   │   └── KeyPickup.cs
│   │   │   │   └── Lever.cs
│   │   │   ├── Player/
│   │   │   │   └── InteractionDetector.cs
│   │   │   │   └── PlayerInventory.cs
│   │   │   │   └── PlayerMovementController.cs
│   │   │   └── UI/
│   │   │       └── HoldProgressBarUI.cs
│   │   │       └── InventoryController
│   │   └── Editor/
│   ├── ScriptableObjects/
│   │   ├── Items/
│   │   │   └── SO_Key.cs
│   ├── Prefabs/
│   │   │   └── P_Canvas
│   │   │   └── P_Chest
│   │   │   └── P_Directional Light
│   │   │   └── P_Doors
│   │   │   └── P_Enviroments
│   │   │   └── P_Enviroments
│   │   │   └── P_Glovel Volume
│   │   │   └── P_Grounds
│   │   │   └── P_Key
│   │   │   └── P_Lever
│   │   │   └── P_Player
│   │   │   └── P_UI_Crosshair
│   │   │   └── P_UI_HoldProgressBar
│   │   │   └── P_UI_PlayerInventory
│   ├── Materials/
│   └── Scenes/
│       └── TestScene.unity
├── Docs/
│   ├── CSharp_Coding_Conventions.md
│   ├── Naming_Convention_Kilavuzu.md
│   └── Prefab_Asset_Kurallari.md
├── README.md
├── PROMPTS.md
└── .gitignore
```

---

## İletişim

| Bilgi | Değer |
|-------|-------|
| Ad Soyad | Yusuf Anıl Turgut |
| E-posta | yusufanilturgut22@gmail.com |
| LinkedIn | https://www.linkedin.com/in/yusuf-an%C4%B1l-turgut-814737225/ |
| GitHub | https://github.com/YusufAnilTurgut |

---

*Bu proje Ludu Arts Unity Developer Intern Case için hazırlanmıştır.*
