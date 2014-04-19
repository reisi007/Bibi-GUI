package at.reisisoft.bibigui;

import org.eclipse.jgit.lib.Repository;
import org.eclipse.jgit.storage.file.FileRepositoryBuilder;

import java.io.File;
import java.io.IOException;

public class Git {
    private Repository repository;

    public Git(String folder) throws IOException {
        if (folder == null || folder.length() < 1)
            throw new IllegalArgumentException("folder must not be null");
        repository = new FileRepositoryBuilder().setGitDir(new File(folder)).readEnvironment().findGitDir().build();
    }
}
