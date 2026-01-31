# Interaction System - Yusuf Anıl Turgut
> Ludu Arts Unity Developer Intern Case

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

```
[Mimari diyagram veya açıklama]
```

**Neden bu yapıyı seçtim:**
> [Açıklama]

**Alternatifler:**
> [Düşündüğünüz diğer yaklaşımlar ve neden seçmediniz]

**Trade-off'lar:**
> [Bu yaklaşımın avantaj ve dezavantajları]

### Kullanılan Design Patterns

| Pattern | Kullanım Yeri | Neden |
|---------|---------------|-------|
| [Observer] | [Event system] | [Açıklama] |
| [State] | [Door states] | [Açıklama] |
| [vb.] | | |

---

## Ludu Arts Standartlarına Uyum

### C# Coding Conventions

| Kural | Uygulandı | Notlar |
|-------|-----------|--------|
| m_ prefix (private fields) | [x] / [ ] | |
| s_ prefix (private static) | [x] / [ ] | |
| k_ prefix (private const) | [x] / [ ] | |
| Region kullanımı | [x] / [ ] | |
| Region sırası doğru | [x] / [ ] | |
| XML documentation | [x] / [ ] | |
| Silent bypass yok | [x] / [ ] | |
| Explicit interface impl. | [x] / [ ] | |

### Naming Convention

| Kural | Uygulandı | Örnekler |
|-------|-----------|----------|
| P_ prefix (Prefab) | [x] / [ ] | P_Door, P_Chest |
| M_ prefix (Material) | [x] / [ ] | M_Door_Wood |
| T_ prefix (Texture) | [x] / [ ] | |
| SO isimlendirme | [x] / [ ] | |

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

- [x] / [ ] Core Interaction System
  - [x] / [ ] IInteractable interface
  - [x] / [ ] InteractionDetector
  - [x] / [ ] Range kontrolü

- [x] / [ ] Interaction Types
  - [x] / [ ] Instant
  - [x] / [ ] Hold
  - [x] / [ ] Toggle

- [x] / [ ] Interactable Objects
  - [x] / [ ] Door (locked/unlocked)
  - [x] / [ ] Key Pickup
  - [x] / [ ] Switch/Lever
  - [x] / [ ] Chest/Container

- [x] / [ ] UI Feedback
  - [x] / [ ] Interaction prompt
  - [x] / [ ] Dynamic text
  - [x] / [ ] Hold progress bar
  - [x] / [ ] Cannot interact feedback

- [x] / [ ] Simple Inventory
  - [x] / [ ] Key toplama
  - [x] / [ ] UI listesi

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
2. [Özellik] - [Neden]

### Bilinen Bug'lar
1. [Bug açıklaması] - [Reproduce adımları]
2. [Bug]

### İyileştirme Önerileri
1. [Öneri] - [Nasıl daha iyi olabilirdi]
2. [Öneri]

---

## Ekstra Özellikler

Zorunlu gereksinimlerin dışında eklediklerim:

1. **[Özellik Adı]**
   - Açıklama: [Ne yapıyor]
   - Neden ekledim: [Motivasyon]

2. **[Özellik Adı]**
   - ...

---

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
