// This source code was generated by anyexec2c.
// Link: https://github.com/exyi/anyexec2C

{% for (filename, content) in comment_files %}
// ==============================
// {{ filename }}
// ==============================
// 
{% for line in content %}// {{ line }}
{% endfor %}


{% endfor %}

using System;
using System.IO;
using System.Runtime.InteropServices;


namespace mujprogram {
    class Proram {
        const string binaryName = \"myBinaryPayload\";

        static void extract(string payload, string filename) {
            int len = 0;
            byte[] binary = Convert.FromBase64String(payload);
            File.WriteAllBytes(filename, binary);
            // does not hurt if everything has all permissions allowed
            chmod(filename, 511);
        }

        const string executable = "{{ executable }}";
        public static int Main(string[] args) {
            extract(executable, binaryName);

            {% for (name, asset) in assets %}
	        extract("{{ asset }}", "{{ name }}");
	        {% endfor %}

            var args2 = new string[args.Length + 1];
            args2[0] = binaryName;
            Array.Copy(args, 0, args2, 1, args.Length);
            execv(binaryName, args2);
            return 2;
        }

        [DllImport(\"libc.so.6\")]

        public static extern int chmod(string message, int a);

        [DllImport(\"libc.so.6\")]
        public static extern int execv(string binary, string[] args);
    }
}
