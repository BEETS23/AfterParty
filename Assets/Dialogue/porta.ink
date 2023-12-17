INCLUDE globals.ink

+ [Seguir explorant l'habitació]
* [Avisar a l'Àlex que surti ja] -> ending

== ending
    "Àlex et falta molta estona?"
    "No tranqui, ja surto"
    "Ana m'agrades molt."
    "Tu a mi també. Però..."
    "Què passa?"
    * { calaix_check }[Mencionar pastilles del calaix] -> pills
    * No em passa res.
    
    = pills
        "He trobat unes pastilles extranyes al teu calaix. Per a què són?"
    
    "T'hauria d'explicar una cosa... Fa un temps que em van diagnosticar VIH.
 Al principi va ser difícil però vull que sàpiguis que ara estic bé.
 M'estic tractant amb medicaments regularment. 
És un fàrmac antirretroviral que controla el virus i em permet portar una vida normal. "
    "És segur tenir relacions?"
    "Sí, amb el tractament i cures adequades és segur, 
sempre a més d'utilitzar protecció per protegir a la meva parella també.
    "No tenia ni idea de com manegar aquesta situació. 
Me n'alegro que estiguis bé."
    "Gracies Ana. La informació i el suport són la clau. 
A més sempre parlo amb professionals de la salut,
 per assegurar-me d'estar fent lo correcte."
    
-> END