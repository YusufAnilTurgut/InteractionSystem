# PROMPTS.md

## 📌 Amaç

Bu doküman, **InteractionSystem** Unity projesinde Large Language Model (LLM) kullanımı için standart prompt kurallarını, örneklerini ve beklentileri tanımlar.

Amaç:

* Kod kalitesini ve tutarlılığı korumak
* Unity / C# best-practice’lerine uygun çıktılar almak
* Ekip içinde ortak bir LLM kullanım dili oluşturmak

---

## 🧠 Genel Kurallar

LLM’den istenen tüm kodlar aşağıdaki kurallara **uymak zorundadır**:

* Kod dili **C#** olmalıdır
* Unity sürümü varsayımı: **2021 LTS+**
* Kod **English naming** kullanmalıdır
* `MonoBehaviour`, `ScriptableObject`, `UnityEvent` Unity standartlarına uygun yazılmalıdır
* Gereksiz yorum satırı yazılmamalıdır
* `public` alanlar yalnızca Inspector için kullanılmalıdır
* `SerializeField + private` tercih edilmelidir

---

## 📁 Proje Yapısı Varsayımı

Prompt yazarken şu yapı varsayılır:

```
Assets/
└── InteractionSystem/
    ├── Scripts/
    │   ├── Runtime/
    │   │   ├── Core/
    │   │   ├── Interactables/
    │   │   ├── Player/
    │   │   └── UI/
    │   └── Editor/
    ├── ScriptableObjects/
    │   └── Items/
    ├── Prefabs/
    └── Scenes/
```

LLM çıktıları bu yapıya uygun dosya önerileri içermelidir.

---

## 🧩 Kod Yazdırma Prompt Örnekleri

### 1️⃣ Interactable Class

**Prompt:**

```
Unity için IInteractable interface’ini implemente eden, hold destekli bir DoorInteractable yaz.
- UnityEvent kullansın
- Inspector-friendly olsun
- InteractionText expose edilsin
```

**Beklenen:**

* `InteractableBase`’ten türeyen class
* `OnInteract` veya `OnHoldCompleted` event

---

### 2️⃣ ScriptableObject (Item / Key)

**Prompt:**

```
Unity’de kullanılmak üzere bir KeyItem ScriptableObject yaz.
- CreateAssetMenu attribute’u olsun
- Id, DisplayName ve Icon içersin
```

---

### 3️⃣ UI Component

**Prompt:**

```
Interaction prompt göstermek için basit bir UI component yaz.
- TMP_Text kullansın
- SetText(string) methodu olsun
```

---

## 🚫 Kaçınılması Gereken İstekler

Aşağıdaki istekler **istenmemelidir**:

* Reflection-heavy çözümler
* Singleton overuse
* Update() içinde sürekli çalışan event çağrıları
* Scene’e bağımlı ScriptableObject state

---

## ⚙️ Event & Architecture Tercihleri

* Designer-facing logic → `UnityEvent`
* Core gameplay logic → `C# event / Action`
* Data tanımı → `ScriptableObject`
* Davranış → `MonoBehaviour`

---

## 🧪 Test & Genişletilebilirlik

LLM’den yazdırılan kodlar:

* Reusable olmalı
* Hard-coded referans içermemeli
* Farklı sahnelerde çalışabilir olmalı

---

## ✅ Check List (Prompt Sonrası)

Her LLM çıktısından sonra şu sorular sorulmalıdır:

* Kod Unity’de compile olur mu?
* Inspector’dan rahatça kullanılabilir mi?
* InteractionSystem mimarisine uyuyor mu?
* Gereksiz bağımlılık var mı?

---

## 📝 Notlar

Bu doküman yaşayan bir dokümandır.
Proje ilerledikçe yeni prompt örnekleri ve kurallar eklenmelidir.

---

**InteractionSystem – LLM Usage Guide**
