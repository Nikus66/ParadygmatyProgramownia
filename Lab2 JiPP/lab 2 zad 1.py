from collections import Counter

# Przykładowy tekst
tekst = """
Results from a phase 3 clinical trial show promise for a new standard of care for treating people with advanced cervical cancer. AzmanL/Getty Images
A phase 3 clinical trial suggests a new standard of care for treating people with advanced cervical cancer.
The recommendation includes a combination of induction chemotherapy followed by chemoradiotherapy.
The researchers are interested in how future studies can investigate the use of immunotherapies to further improve survival rates.
Clinicians are hopeful the new approach will give people with aggressive cervical cancer additional options for treatment, particularly those who face barriers to healthcare.
Cervical cancer affects approximately 11,500Trusted Source people in the United States each year and 660,000Trusted Source people worldwide.

A phase 3 clinical trial recently published in The LancetTrusted Source proposes a new standard of care for people with cervical cancer who aren’t candidates for surgery. The recommendation includes a combination of induction chemotherapy followed by chemoradiotherapy instead of chemoradiotherapy alone.

Compared to participants who received only chemoradiotherapy, those who received both induction chemotherapy and chemoradiotherapy saw an increase from 64% to 72% in their 5-year progression-free survival rates.

The INTERLACE trial included 500 participants from medical centers in Brazil, India, Italy, Mexico, and the United Kingdom, all of whom had locally advanced cervical cancer.

“Prior to this study, doing chemotherapy before chemotherapy and radiation in combination had not really demonstrated benefit,” said Joshua G. Cohen, MD, medical director of the gynecologic cancer program at City of Hope Orange County, CA, told Healthline. Cohen wasn’t involved in the study.

“This was a large trial, an international trial [that] took over 10 years to complete, but certainly a study that gives us another option to offer patients, which is fabulous,” Cohen told Healthline.
"""

# Stop words
stop_words = {'i', 'a', 'the', 'and', 'is', 'with'}

# Liczba słów, zdań i akapitów
slowa = re.findall(r'\b\w+\b', tekst)
zdania = re.findall(r'[^.!?]*[.!?]', tekst)
akapity = tekst.strip().split('\n\n')

liczba_slow = len(slowa)
liczba_zdan = len(zdania)
liczba_akapitow = len(akapity)

print(f'Słowa: {liczba_slow}')
print(f'Zdania: {liczba_zdan}')
print(f'Akapity: {liczba_akapitow}')

# Najczęściej występujące słowa, wykluczając stop words
przefiltrowane_slowa = [slowo.lower() for slowo in slowa if slowo.lower() not in stop_words]
najczesciej_wystepujace_slowa = Counter(przefiltrowane_slowa).most_common(5)
print('Najczęściej występujące słowa:', najczesciej_wystepujace_slowa)

# Transformacja słów zaczynających się na 'a' lub 'A'
zmienione_slowa = [slowo[::-1] if slowo.lower().startswith('a') else slowo for slowo in slowa]
zmieniony_tekst = ' '.join(zmienione_slowa)
print('Zmieniony tekst:', zmieniony_tekst)